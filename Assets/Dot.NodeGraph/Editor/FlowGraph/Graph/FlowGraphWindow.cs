using DotEngine.NodeGraph.Flow;
using GraphProcessor;
using UnityEngine;

namespace DotEditor.NodeGraph
{
    public class FlowGraphWindow : BaseGraphWindow
    {
        private FlowGraph flowGraph;

        public static void ShowWindow(FlowGraph flowGraph)
        {
            var win = CreateWindow<FlowGraphWindow>();
            win.titleContent = new GUIContent("Flow Graph Window");

            win.InitializeGraph(flowGraph);

            win.Show();
        }

        protected override void InitializeWindow(BaseGraph graph)
        {
            flowGraph = graph as FlowGraph;

            if(graphView == null)
            {
                graphView = new FlowGraphView(this);
                graphView.Add(new MiniMapView(graphView));
            }

            rootView.Add(graphView);
        }

        protected override void OnDestroy()
        {
            graphView?.Dispose();
        }
    }
}
