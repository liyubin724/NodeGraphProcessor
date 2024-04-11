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
        public struct PortDescription
        {
            public Type nodeType;
            public Type portType;
            public bool isInput;
            public string portFieldName;
            public string portIdentifier;
            public string portDisplayName;
        }

        private static Dictionary<Type, MonoScript> sm_NodeViewScripts = new Dictionary<Type, MonoScript>();
        private static Dictionary<Type, MonoScript> sm_NodeScripts = new Dictionary<Type, MonoScript>();
        private static Dictionary<Type, Type> sm_NodeViewPerType = new Dictionary<Type, Type>();

        public class NodeDescriptions
        {
            public Dictionary<string, Type> nodePerMenuTitle = new Dictionary<string, Type>();
            public List<Type> slotTypes = new List<Type>();
            public List<PortDescription> nodeCreatePortDescription = new List<PortDescription>();
        }

        public struct NodeSpecificToGraph
        {
            public Type nodeType;
            public List<MethodInfo> isCompatibleWithGraph;
            public Type compatibleWithGraphType;
        }

        private static Dictionary<BaseGraph, NodeDescriptions> sm_SpecificNodeDescriptions = new Dictionary<BaseGraph, NodeDescriptions>();
        private static List<NodeSpecificToGraph> sm_SpecificNodes = new List<NodeSpecificToGraph>();

        private static NodeDescriptions sm_GenericNodes = new NodeDescriptions();

        static NodeProvider()
        {
            BuildScriptCache();
            BuildGenericNodeCache();
        }

        public static void LoadGraph(BaseGraph graph)
        {
            // Clear old graph data in case there was some
            sm_SpecificNodeDescriptions.Remove(graph);
            var descriptions = new NodeDescriptions();
            sm_SpecificNodeDescriptions.Add(graph, descriptions);

            var graphType = graph.GetType();
            foreach (var nodeInfo in sm_SpecificNodes)
            {
                bool compatible = nodeInfo.compatibleWithGraphType == null || nodeInfo.compatibleWithGraphType == graphType;

                if (nodeInfo.isCompatibleWithGraph != null)
                {
                    foreach (var method in nodeInfo.isCompatibleWithGraph)
                        compatible &= (bool)method?.Invoke(null, new object[] { graph });
                }

                if (compatible)
                    BuildCacheForNode(nodeInfo.nodeType, descriptions, graph);
            }
        }

        public static void UnloadGraph(BaseGraph graph)
        {
            sm_SpecificNodeDescriptions.Remove(graph);
        }

        static void BuildGenericNodeCache()
        {
            foreach (var nodeType in TypeCache.GetTypesDerivedFrom<BaseNode>())
            {
                if (!IsNodeAccessible(nodeType))
                    continue;

                if (IsNodeSpecificToGraph(nodeType))
                    continue;

                BuildCacheForNode(nodeType, sm_GenericNodes);
            }
        }

        static void BuildCacheForNode(Type nodeType, NodeDescriptions targetDescription, BaseGraph graph = null)
        {
            var attrs = nodeType.GetCustomAttributes(typeof(NodeMenuItemAttribute), false) as NodeMenuItemAttribute[];

            if (attrs != null && attrs.Length > 0)
            {
                foreach (var attr in attrs)
                    targetDescription.nodePerMenuTitle[attr.menuPath] = nodeType;
            }

            foreach (var field in nodeType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (field.GetCustomAttribute<HideInInspector>() == null && field.GetCustomAttributes().Any(c => c is InputAttribute || c is OutputAttribute))
                    targetDescription.slotTypes.Add(field.FieldType);
            }

            ProvideNodePortCreationDescription(nodeType, targetDescription, graph);
        }

        static bool IsNodeAccessible(Type nodeType)
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

        static bool IsNodeCompatibleToGraph(Type nodeType, Type graphType)
        {
            var nodeIdentityAttr = nodeType.GetCustomAttribute<NodeIdentityAttribute>();
            if (nodeIdentityAttr == null)
            {
                return false;
            }

            if (nodeIdentityAttr.tags == null || nodeIdentityAttr.tags.Length == 0)
            {
                return true;
            }

            var graphIdentityAttr = graphType.GetCustomAttribute<GraphIdentifyAttribute>();
            if (graphIdentityAttr == null)
            {
                return false;
            }

            var nodeTags = nodeIdentityAttr.tags;
            var graphNodeTags = graphIdentityAttr.nodeTags;
            foreach (var tag in graphNodeTags)
            {
                if (Array.IndexOf(nodeTags, tag) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        // Check if node has anything that depends on the graph type or settings
        static bool IsNodeSpecificToGraph(Type nodeType)
        {
            var isCompatibleWithGraphMethods = nodeType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy).Where(m => m.GetCustomAttribute<IsCompatibleWithGraph>() != null);
            var nodeMenuAttributes = nodeType.GetCustomAttributes<NodeMenuItemAttribute>();

            List<Type> compatibleGraphTypes = nodeMenuAttributes.Where(n => n.onlyCompatibleWithGraph != null).Select(a => a.onlyCompatibleWithGraph).ToList();

            List<MethodInfo> compatibleMethods = new List<MethodInfo>();
            foreach (var method in isCompatibleWithGraphMethods)
            {
                // Check if the method is static and have the correct prototype
                var p = method.GetParameters();
                if (method.ReturnType != typeof(bool) || p.Count() != 1 || p[0].ParameterType != typeof(BaseGraph))
                    Debug.LogError($"The function '{method.Name}' marked with the IsCompatibleWithGraph attribute either doesn't return a boolean or doesn't take one parameter of BaseGraph type.");
                else
                    compatibleMethods.Add(method);
            }

            if (compatibleMethods.Count > 0 || compatibleGraphTypes.Count > 0)
            {
                // We still need to add the element in specificNode even without specific graph
                if (compatibleGraphTypes.Count == 0)
                    compatibleGraphTypes.Add(null);

                foreach (var graphType in compatibleGraphTypes)
                {
                    sm_SpecificNodes.Add(new NodeSpecificToGraph
                    {
                        nodeType = nodeType,
                        isCompatibleWithGraph = compatibleMethods,
                        compatibleWithGraphType = graphType
                    });
                }
                return true;
            }
            return false;
        }

        static void BuildScriptCache()
        {
            foreach (var nodeType in TypeCache.GetTypesDerivedFrom<BaseNode>())
            {
                if (!IsNodeAccessible(nodeType))
                    continue;

                AddNodeScriptAsset(nodeType);
            }

            foreach (var nodeViewType in TypeCache.GetTypesDerivedFrom<BaseNodeView>())
            {
                if (nodeViewType.IsAbstract)
                {
                    continue;
                }

                AddNodeViewScriptAsset(nodeViewType);
            }
        }

        static FieldInfo SetGraph = typeof(BaseNode).GetField("graph", BindingFlags.NonPublic | BindingFlags.Instance);
        static void ProvideNodePortCreationDescription(Type nodeType, NodeDescriptions targetDescription, BaseGraph graph = null)
        {
            var node = Activator.CreateInstance(nodeType) as BaseNode;
            try
            {
                SetGraph.SetValue(node, graph);
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
                targetDescription.nodeCreatePortDescription.Add(new PortDescription
                {
                    nodeType = nodeType,
                    portType = p.portData.displayType ?? p.fieldInfo.FieldType,
                    isInput = input,
                    portFieldName = p.fieldName,
                    portDisplayName = p.portData.displayName ?? p.fieldName,
                    portIdentifier = p.portData.identifier,
                });
            }
        }

        static void AddNodeScriptAsset(Type type)
        {
            var nodeScriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name);
            // Try find the class name with Node name at the end
            if (nodeScriptAsset == null)
            {
                nodeScriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name + "Node");
            }

            if (nodeScriptAsset != null)
            {
                sm_NodeScripts[type] = nodeScriptAsset;
            }
        }

        static void AddNodeViewScriptAsset(Type type)
        {
            var attrs = type.GetCustomAttributes<CustomNodeEditorAttribute>(false);
            if (attrs == null || attrs.Count() == 0)
            {
                return;
            }

            foreach (var attr in attrs)
            {
                Type nodeType = attr.nodeType;
                sm_NodeViewPerType[nodeType] = type;
            }

            var nodeViewScriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name);
            if (nodeViewScriptAsset == null)
                nodeViewScriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name + "View");
            if (nodeViewScriptAsset == null)
                nodeViewScriptAsset = AssetDatabaseHelper.FindScriptFromClassName(type.Name + "NodeView");

            if (nodeViewScriptAsset != null)
                sm_NodeViewScripts[type] = nodeViewScriptAsset;
        }

        public static Type GetNodeViewTypeFromNodeType(Type nodeType)
        {
            if (sm_NodeViewPerType.TryGetValue(nodeType, out var viewType))
            {
                return viewType;
            }

            nodeType = nodeType.BaseType;
            if (nodeType == null || (nodeType != typeof(BaseNode) && !nodeType.IsSubclassOf(typeof(BaseNode))))
            {
                return null;
            }

            return GetNodeViewTypeFromNodeType(nodeType);
        }

        public static IEnumerable<(string path, Type type)> GetNodeMenuEntries(BaseGraph graph = null)
        {
            foreach (var node in sm_GenericNodes.nodePerMenuTitle)
                yield return (node.Key, node.Value);

            if (graph != null && sm_SpecificNodeDescriptions.TryGetValue(graph, out var specificNodes))
            {
                foreach (var node in specificNodes.nodePerMenuTitle)
                    yield return (node.Key, node.Value);
            }
        }

        public static MonoScript GetNodeViewScript(Type type)
        {
            sm_NodeViewScripts.TryGetValue(type, out var script);

            return script;
        }

        public static MonoScript GetNodeScript(Type type)
        {
            sm_NodeScripts.TryGetValue(type, out var script);

            return script;
        }

        public static IEnumerable<Type> GetSlotTypes(BaseGraph graph = null)
        {
            foreach (var type in sm_GenericNodes.slotTypes)
                yield return type;

            if (graph != null && sm_SpecificNodeDescriptions.TryGetValue(graph, out var specificNodes))
            {
                foreach (var type in specificNodes.slotTypes)
                    yield return type;
            }
        }

        public static IEnumerable<PortDescription> GetEdgeCreationNodeMenuEntry(PortView portView, BaseGraph graph = null)
        {
            foreach (var description in sm_GenericNodes.nodeCreatePortDescription)
            {
                if (!IsPortCompatible(description))
                    continue;

                yield return description;
            }

            if (graph != null && sm_SpecificNodeDescriptions.TryGetValue(graph, out var specificNodes))
            {
                foreach (var description in specificNodes.nodeCreatePortDescription)
                {
                    if (!IsPortCompatible(description))
                        continue;
                    yield return description;
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

        //-------------------------

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
    }
}
