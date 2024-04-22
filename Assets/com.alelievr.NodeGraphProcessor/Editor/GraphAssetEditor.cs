using UnityEditor;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    [CustomEditor(typeof(GraphAsset), true)]
    public class GraphAssetEditor : GraphInspector
    {
        protected override void CreateInspector()
        {
            base.CreateInspector();

            var openBtn = new Button(() =>
            {
                GraphWindow.OpenWindow(target as GraphAsset);
            });
            openBtn.text = "Open Graph Window";
            root.Add(openBtn);
        }
    }
}
