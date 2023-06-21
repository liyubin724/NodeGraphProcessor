using DotEngine.NodeGraph.Flow;
using UnityEditor;
using UnityEngine.UIElements;

namespace DotEditor.NodeGraph
{
    [CustomEditor(typeof(FlowGraph))]
    public class FlowGraphInspector : Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var rootView = new VisualElement();

            var openBtn = new Button(() =>
            {
                FlowGraphWindow.ShowWindow(target as FlowGraph);
            });
            openBtn.text = "Open Window";
            rootView.Add(openBtn);

            return rootView;
        }
    }
}
