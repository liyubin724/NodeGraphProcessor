using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(AssetFolderPathNode))]
    public class AssetFolderPathNodeView : AssetPathNodeView
    {
        protected override string OpenPathPanel(string fullPath)
        {
#if UNITY_EDITOR
            return EditorUtility.OpenFolderPanel("Folder", fullPath, null);
#else
            return null;
#endif
        }
    }
}
