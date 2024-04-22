using DotEngine.Graph.Assets;
using GraphProcessor;
using UnityEditor;

using AssetUtil = DotEngine.Graph.AssetUtil;

namespace DotEditor.Graph.Assets
{
    [CustomNodeEditor(typeof(FilePathNode))]
    public class FilePathNodeView : PathNodeView
    {
        protected override string OpenPathPanel(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath))
            {
                assetPath = AssetUtil.GetAssetDiskPath();
            }
            else
            {
                assetPath = AssetUtil.GetDiskPath(assetPath);
            }

            string path = EditorUtility.OpenFilePanel("Open File", assetPath, null);
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            return AssetUtil.GetAssetPath(path);
        }
    }
}
