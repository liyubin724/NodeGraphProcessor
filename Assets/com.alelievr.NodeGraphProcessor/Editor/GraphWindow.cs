using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    public class GraphWindow : EditorWindow
    {
        private static Dictionary<Type, Type> sm_GraphWindowDic = new Dictionary<Type, Type>();
        public static void OpenWindow(BaseGraph graph)
        {
            if (!sm_GraphWindowDic.TryGetValue(graph.GetType(), out var winType))
            {
                winType = typeof(GraphWindow);
            }

            var win = GetWindow(winType) as GraphWindow;
            win.titleContent = new GUIContent("Graph Window");
            win.InitWithGraph(graph);
            win.Show();
        }

        static GraphWindow()
        {
            var types = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from type in assembly.GetTypes()
                        where type.IsSubclassOf(typeof(GraphWindow))
                        let attr = type.GetCustomAttribute<CustomGraphWindowAttribute>()
                        where attr != null && attr.graphType != null
                        select type;

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<CustomGraphWindowAttribute>();
                if (!sm_GraphWindowDic.ContainsKey(attr.graphType))
                {
                    sm_GraphWindowDic.Add(attr.graphType, type);
                }
            }
        }

        private VisualElement m_RootView;

        private EnhancedToolbarView m_ToolbarView;
        private BaseGraphView m_GraphView;

        public VisualElement rootView => m_RootView;
        public EnhancedToolbarView toolbarView => m_ToolbarView;
        public BaseGraphView graphView => m_GraphView;

        private BaseGraph m_Graph;
        public BaseGraph graph => m_Graph;

        public event Action<BaseGraph> onGraphLoaded;
        public event Action<BaseGraph> onGraphUnloaded;

        private void CreateGUI()
        {
            CreateRootView();
            CreateToolbarView();
            CreateGraphView();
        }

        private void CreateRootView()
        {
            m_RootView = rootVisualElement;
            m_RootView.name = "graph-root";

            OnInitilizeRootView(rootView);
        }

        private void CreateToolbarView()
        {
            if (m_ToolbarView == null)
            {
                m_ToolbarView = new EnhancedToolbarView();
                m_RootView.Add(m_ToolbarView);
            }

            m_ToolbarView.Clear();

            OnInitilizeToolbarView(m_ToolbarView);
        }

        private void CreateGraphView()
        {
            m_GraphView = new BaseGraphView(this);
            m_RootView.Add(m_GraphView);

            OnInitlizeGraphView(m_GraphView);
        }

        public void InitWithGraph(BaseGraph graph)
        {
            if (m_Graph != null && m_Graph != graph)
            {
                SaveGraph();

                onGraphUnloaded?.Invoke(m_Graph);
                m_Graph = null;
            }

            m_Graph = graph;
            onGraphLoaded?.Invoke(m_Graph);

            if (m_GraphView != null)
            {
                m_RootView.Remove(m_GraphView);
                m_GraphView = null;
            }
        }

        protected virtual void OnInitilizeRootView(VisualElement rootView)
        {
        }

        protected virtual void OnInitilizeToolbarView(EnhancedToolbarView toolbarView)
        {

        }

        protected virtual void OnInitlizeGraphView(BaseGraphView graphView)
        {

        }

        private void SaveGraph()
        {
            if (m_Graph == null)
            {
                return;
            }

            var assetPath = AssetDatabase.GetAssetPath(m_Graph);
            if (string.IsNullOrEmpty(assetPath))
            {
                assetPath = EditorUtility.SaveFilePanelInProject("Save Graph", "graph", "asset", "");
                if (string.IsNullOrEmpty(assetPath))
                {
                    return;
                }

                AssetDatabase.CreateAsset(m_Graph, assetPath);
                AssetDatabase.ImportAsset(assetPath);
            }
            else
            {
                EditorUtility.SetDirty(m_Graph);
                AssetDatabase.SaveAssets();
            }

        }
    }
}
