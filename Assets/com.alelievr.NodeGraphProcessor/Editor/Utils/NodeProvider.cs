using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GraphProcessor
{
    public static class NodeProvider
    {
        public class NodeDescription
        {
            public Type type;
            public MonoScript scriptAsset;
            public string[] menuItems;
            public string[] tags;

            public Type viewType;
            public MonoScript viewScriptAsset;

            public PortDescription[] portDescriptions;
        }

        public struct PortDescription
        {
            public Type nodeType;
            public Type portType;
            public bool isInput;
            public string portFieldName;
            public string portIdentifier;
            public string portDisplayName;
        }

        public static Dictionary<Type, NodeDescription> sm_NodeDic = new Dictionary<Type, NodeDescription>();

        static NodeProvider()
        {
            BuildNodeCache();
        }

        private static void BuildNodeCache()
        {
            sm_NodeDic.Clear();

            foreach (var nodeType in TypeCache.GetTypesDerivedFrom<BaseNode>())
            {
                var desc = new NodeDescription();
                desc.type = nodeType;
                desc.scriptAsset = FindNodeScriptAsset(nodeType);
                desc.menuItems = (
                        from attr in nodeType.GetCustomAttributes<NodeMenuItemAttribute>(false)
                        where attr != null && !string.IsNullOrEmpty(attr.menuPath)
                        select attr.menuPath
                    ).ToArray();
                desc.tags = nodeType.GetCustomAttribute<NodeIdentityAttribute>()?.tags;

                desc.portDescriptions = GetNodePorts(nodeType);

                sm_NodeDic.Add(nodeType, desc);
            }

            foreach (var viewType in TypeCache.GetTypesDerivedFrom<BaseNodeView>())
            {
                var scriptAsset = FindNodeViewScriptAsset(viewType);

                var attrs = viewType.GetCustomAttributes<CustomNodeEditorAttribute>();
                foreach (var attr in attrs)
                {
                    if (attr.nodeType != null)
                    {
                        if (sm_NodeDic.TryGetValue(attr.nodeType, out var desc))
                        {
                            desc.viewType = viewType;
                            desc.viewScriptAsset = scriptAsset;
                        }
                    }
                }
            }

        }

        private static bool IsNodeTypeAccessible(Type nodeType)
        {
            if (nodeType.IsAbstract)
            {
                return false;
            }

            var identityAttr = nodeType.GetCustomAttribute<NodeIdentityAttribute>();
            if (identityAttr == null || !identityAttr.enable)
            {
                return false;
            }

            return nodeType.GetCustomAttributes<NodeMenuItemAttribute>().Count() > 0;
        }

        public static Type GetNodeViewTypeFromNodeType(Type nodeType)
        {
            if (sm_NodeDic.TryGetValue(nodeType, out var nodeDesc) && nodeDesc.viewType != null)
            {
                return nodeDesc.viewType;
            }

            nodeType = nodeType.BaseType;
            if (nodeType == null || (nodeType != typeof(BaseNode) && !nodeType.IsSubclassOf(typeof(BaseNode))))
            {
                return null;
            }

            return GetNodeViewTypeFromNodeType(nodeType);
        }

        private static PortDescription[] GetNodePorts(Type nodeType)
        {
            if (nodeType.IsAbstract)
            {
                return null;
            }

            var ports = new List<PortDescription>();

            var node = Activator.CreateInstance(nodeType) as BaseNode;
            try
            {
                node.InitializePorts();
                node.UpdateAllPorts();
            }
            catch (Exception) { }

            foreach (var p in node.inputPorts)
                AddPort(p, true);
            foreach (var p in node.outputPorts)
                AddPort(p, false);

            void AddPort(NodePort p, bool input)
            {
                ports.Add(new PortDescription
                {
                    nodeType = nodeType,
                    portType = p.portData.displayType ?? p.fieldInfo.FieldType,
                    isInput = input,
                    portFieldName = p.fieldName,
                    portDisplayName = p.portData.displayName ?? p.fieldName,
                    portIdentifier = p.portData.identifier,
                });
            }

            return ports.ToArray();
        }

        #region MonoScript

        private static MonoScript FindNodeScriptAsset(Type type)
        {
            var scriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name);
            if (scriptAsset == null)
            {
                scriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name + "Node");
            }

            return scriptAsset;
        }

        private static MonoScript FindNodeViewScriptAsset(Type type)
        {
            var scriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name);

            if (scriptAsset == null)
            {
                scriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name + "View");
            }

            if (scriptAsset == null)
            {
                scriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name + "NodeView");
            }

            return scriptAsset;
        }

        private static MonoScript sm_BaseNodeViewScriptAsset;
        public static MonoScript GetNodeViewScript(Type type)
        {
            if (type == typeof(BaseNodeView))
            {
                if (sm_BaseNodeViewScriptAsset == null)
                {
                    sm_BaseNodeViewScriptAsset = FindNodeViewScriptAsset(typeof(BaseNodeView));
                }
                return sm_BaseNodeViewScriptAsset;
            }

            var attrs = type.GetCustomAttributes<CustomNodeEditorAttribute>();
            if (attrs != null)
            {
                foreach (var attr in attrs)
                {
                    if (attr.nodeType != null && sm_NodeDic.TryGetValue(attr.nodeType, out var nodeDesc))
                    {
                        return nodeDesc.viewScriptAsset;
                    }
                }
            }

            return null;
        }

        public static MonoScript GetNodeScript(Type type)
        {
            if (sm_NodeDic.TryGetValue(type, out var nodeDesc))
            {
                return nodeDesc.scriptAsset;
            }

            return null;
        }
        #endregion

        #region Create Node
        /// <summary>
        /// Creates a node of type T at a certain position
        /// </summary>
        /// <param name="position">position in the graph in pixels</param>
        /// <typeparam name="T">type of the node</typeparam>
        /// <returns>the node instance</returns>
        public static T CreateNodeFromType<T>(Vector2 position) where T : BaseNode
        {
            return CreateNodeFromType(typeof(T), position) as T;
        }

        /// <summary>
        /// Creates a node of type nodeType at a certain position
        /// </summary>
        /// <param name="position">position in the graph in pixels</param>
        /// <typeparam name="nodeType">type of the node</typeparam>
        /// <returns>the node instance</returns>
        public static BaseNode CreateNodeFromType(Type nodeType, Vector2 position)
        {
            if (!nodeType.IsSubclassOf(typeof(BaseNode)))
            {
                throw new ArgumentException("The type is not a subclass of BaseNode");
            }

            var node = Activator.CreateInstance(nodeType) as BaseNode;
            node.position = new Rect(position, new Vector2(100, 100));
            node.OnNodeCreated();

            return node;
        }

        #endregion

        #region MenuEntry
        public static IEnumerable<(string path, Type type)> GetNodeMenuEntries(BaseGraph graph = null)
        {
            foreach (var nodeDesc in sm_NodeDic.Values)
            {
                if (IsNodeCompatibleToGraph(nodeDesc.type, graph?.GetType()))
                {
                    foreach (var menuItem in nodeDesc.menuItems)
                    {
                        yield return (menuItem, nodeDesc.type);
                    }
                }
            }
        }

        public static IEnumerable<PortDescription> GetEdgeCreationNodeMenuEntry(PortView portView, BaseGraph graph = null)
        {
            foreach (var nodeDesc in sm_NodeDic.Values)
            {
                if (IsNodeCompatibleToGraph(nodeDesc.type, graph?.GetType()))
                {
                    foreach (var portDesc in nodeDesc.portDescriptions)
                    {
                        if (!IsPortCompatible(portDesc))
                            continue;

                        yield return portDesc;
                    }
                }
            }

            bool IsPortCompatible(PortDescription description)
            {
                if ((portView.direction == Direction.Input && description.isInput) || (portView.direction == Direction.Output && !description.isInput))
                    return false;

                if (!BaseGraph.TypesAreConnectable(description.portType, portView.portType))
                    return false;

                return true;
            }
        }

        static bool IsNodeCompatibleToGraph(Type nodeType, Type graphType)
        {
            if (!IsNodeTypeAccessible(nodeType))
            {
                return false;
            }

            if (graphType == null)
            {
                return true;
            }

            var graphIdentityAttr = graphType.GetCustomAttribute<GraphIdentifyAttribute>();
            if (graphIdentityAttr == null)
            {
                return true;
            }

            var includeTags = graphIdentityAttr.includeTags;
            var excludeTags = graphIdentityAttr.excludeTags;

            var nodeIdentityAttr = nodeType.GetCustomAttribute<NodeIdentityAttribute>();
            var tags = nodeIdentityAttr.tags;
            var isCompatible = false;
            if (includeTags != null && includeTags.Length > 0)
            {
                if (tags == null)
                {
                    isCompatible = false;
                }
                else
                {
                    foreach (var tag in tags)
                    {
                        if (Array.IndexOf(includeTags, tag) >= 0)
                        {
                            isCompatible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                isCompatible = true;
            }

            if (excludeTags != null && excludeTags.Length > 0)
            {
                foreach (var tag in tags)
                {
                    if (Array.IndexOf(excludeTags, tag) >= 0)
                    {
                        isCompatible = false;
                        break;
                    }
                }
            }

            return isCompatible;
        }

        #endregion

        private static string[] sm_PortStyles;
        public static string[] FindPortStyles()
        {
            if (sm_PortStyles != null)
            {
                return sm_PortStyles;
            }

            var methodInfos = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                              from type in assembly.GetTypes()
                              from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                              let attr = method.GetCustomAttribute<CustomPortStyleAttribute>()
                              where attr != null
                              select method;
            List<string> portStyles = new List<string>();
            foreach (var methodInfo in methodInfos)
            {
                var paths = methodInfo.Invoke(null, null) as string[];
                if (paths != null && paths.Length > 0)
                {
                    portStyles.AddRange(paths);
                }
            }
            sm_PortStyles = portStyles.Distinct().ToArray();

            return sm_PortStyles;
        }
    }
}
