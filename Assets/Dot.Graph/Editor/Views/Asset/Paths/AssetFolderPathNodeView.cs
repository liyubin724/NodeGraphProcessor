using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(AssetFolderPathNode))]
    public class AssetFolderPathNodeView : AssetPathNodeView
    {
        protected override string OpenPathPanel(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath))
            {
                assetPath = AssetUtil.GetAssetPath();
            }
            else
            {
                assetPath = AssetUtil.GetDiskFilePath(assetPath);
            }
            string path = EditorUtility.OpenFolderPanel("Open File", assetPath, null);
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            return AssetUtil.GetAssetFilePath(path);
        }
    }
}
