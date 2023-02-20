using GraphProcessor;
using UnityEditor;
using UnityEngine.UIElements;

namespace GraphProcessor
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
                if (previewNode.input == null)
                {
                    preview.image = null;
                }
                else
                {
                    preview.image = AssetPreview.GetAssetPreview(previewNode.input) ?? AssetPreview.GetMiniThumbnail(previewNode.input);
                }
            };
            controlsContainer.Add(preview);
        }
    }
}