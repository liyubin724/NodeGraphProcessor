using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    [CustomNodeEditor(typeof(DotEngine.Graph.Assets.FilePathNode))]
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
