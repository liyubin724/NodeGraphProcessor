using DotEngine.NodeGraph.Flow;
using GraphProcessor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace DotEditor.NodeGraph
{
    public class FlowGraphWindow : BaseGraphWindow
    {
        public static void ShowWindow(FlowGraph flowGraph)
        {
            var win = CreateWindow<FlowGraphWindow>();
            win.titleContent = new GUIContent("Flow Graph Window");

            win.InitializeGraph(flowGraph);

            win.Show();
        }

        private bool isShow = false;
        protected override void InitializeWindow(BaseGraph graph)
        {
            if (graphView == null)
            {
                graphView = new FlowGraphView(this);
                graphView.Add(new MiniMapView(graphView));

                var toolbar = new Toolbar();
                var toggleProcessPanel = new ToolbarToggle();
                toggleProcessPanel.text = "Show Processor";
                toggleProcessPanel.RegisterValueChangedCallback(evt =>
                {
                    isShow = !isShow;
                    graphView.ToggleView<FlowGraphProcessorView>();
                });
                toolbar.Add(toggleProcessPanel);

                graphView.Add(toolbar);
            }

            rootView.Add(graphView);
        }

        protected override void InitializeGraphView(BaseGraphView view)
        {
            base.InitializeGraphView(view);
        }

        protected override void OnDestroy()
        {
            graphView?.Dispose();
        }
    }
}
