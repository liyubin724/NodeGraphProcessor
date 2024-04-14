using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(AssetFilePathNode))]
    public class AssetFilePathNodeView : AssetPathNodeView
    {
        protected override string OpenPathPanel(string fullPath)
        {
#if UNITY_EDITOR
            return EditorUtility.OpenFilePanel("File", fullPath, null);
#else
            return null;
#endif
        }
    }
}
