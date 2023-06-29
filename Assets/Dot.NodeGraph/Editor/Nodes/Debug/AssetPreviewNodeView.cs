using DotEngine.NodeGraph;
using GraphProcessor;
using UnityEditor;
using UnityEngine.UIElements;

namespace DotEditor.NodeGraph
{
    [NodeCustomEditor(typeof(AssetPreviewNode))]
    public class AssetPreviewNodeView : BaseNodeView
    {
        public override void Enable()
        {
            var previewNode = nodeTarget as AssetPreviewNode;

            var preview = new Image();
            previewNode.onProcessed += () =>
            {
                if (previewNode.asset == null)
                {
                    preview.image = null;
                }
                else
                {
                    preview.image = AssetPreview.GetAssetPreview(previewNode.asset) ?? AssetPreview.GetMiniThumbnail(previewNode.asset);
                }
            };
            controlsContainer.Add(preview);
        }
    }
}
