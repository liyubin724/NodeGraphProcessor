using UnityEditor;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    [CustomEditor(typeof(BaseGraph), true)]
    public class GraphEditor : GraphInspector
    {
        protected override void CreateInspector()
        {
            base.CreateInspector();

            var openBtn = new Button(() =>
            {
                GraphWindow.OpenWindow(target as BaseGraph);
            })
            {
                text = "Open Graph Window"
            };
            root.Add(openBtn);
        }
    }
}
