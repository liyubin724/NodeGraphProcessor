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
        public static void OpenWindow(GraphAsset graph)
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

        private GraphAsset m_GraphAsset;
        public GraphAsset graph => m_GraphAsset;

        public event Action<GraphAsset> onGraphLoaded;
        public event Action<GraphAsset> onGraphUnloaded;

        private void CreateGUI()
        {
            m_RootView = rootVisualElement;
            m_RootView.name = "graph-root";

            m_GraphView = new BaseGraphView(this);
            m_RootView.Add(m_GraphView);

            m_ToolbarView = new EnhancedToolbarView();
            m_RootView.Add(m_ToolbarView);
        }

        public void InitWithGraph(GraphAsset graphAsset)
        {
            if (m_GraphAsset != null && m_GraphAsset != graphAsset)
            {
                SaveGraphAsset();

                onGraphUnloaded?.Invoke(m_GraphAsset);
            }

            m_GraphAsset = graphAsset;
            onGraphLoaded?.Invoke(m_GraphAsset);

            m_GraphView.Initialize(m_GraphAsset);

            RefreshGraphView();
            RefreshToolbarView();
        }

        private void RefreshToolbarView()
        {
            m_ToolbarView.Clear();

            m_ToolbarView.AddLeftButton("Save", () =>
            {
                SaveGraphAsset();
            });
            m_ToolbarView.AddLeftButton("Center", () =>
            {
                m_GraphView.ResetPositionAndZoom();
            });

            m_ToolbarView.AddRightButton("Ping", () =>
            {
                PingGraphAsset();
            });

            OnRefreshToolbarView(m_ToolbarView);
        }

        private void RefreshGraphView()
        {
            OnRefreshGraphView(m_GraphView);
        }

        protected virtual void OnRefreshToolbarView(EnhancedToolbarView toolbarView) { }
        protected virtual void OnRefreshGraphView(BaseGraphView graphView) { }

        private void SaveGraphAsset()
        {
            if (m_GraphAsset == null)
            {
                return;
            }

            var assetPath = AssetDatabase.GetAssetPath(m_GraphAsset);
            if (string.IsNullOrEmpty(assetPath))
            {
                assetPath = EditorUtility.SaveFilePanelInProject("Save Graph", "graph", "asset", "");
                if (string.IsNullOrEmpty(assetPath))
                {
                    return;
                }

                AssetDatabase.CreateAsset(m_GraphAsset, assetPath);
                AssetDatabase.ImportAsset(assetPath);
            }
            else
            {
                EditorUtility.SetDirty(m_GraphAsset);
                AssetDatabase.SaveAssets();
            }

        }

        private void PingGraphAsset()
        {
            if (m_GraphAsset == null)
            {
                return;
            }

            var assetPath = AssetDatabase.GetAssetPath(m_GraphAsset);
            if (!string.IsNullOrEmpty(assetPath))
            {
                EditorGUIUtility.PingObject(m_GraphAsset);
            }
        }
    }
}
