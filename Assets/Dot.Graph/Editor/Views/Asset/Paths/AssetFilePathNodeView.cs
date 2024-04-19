using DotEngine.Graph;
using DotEngine.Graph.Assets;
using GraphProcessor;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    [CustomNodeEditor(typeof(AssetFilePathNode))]
    public class AssetFilePathNodeView : AssetPathNodeView
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
            string path = EditorUtility.OpenFilePanel("Open File", assetPath, null);
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            return AssetUtil.GetAssetFilePath(path);
        }
    }
}
