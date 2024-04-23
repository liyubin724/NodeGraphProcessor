using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;
using UnityEngine.UIElements;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(UObjectPreviewNode))]
    public class UObjectPreviewNodeView : BaseNodeView
    {
        private UObjectPreviewNode m_PreviewNode;

        private Image m_PreviewImage;
        public override void Enable()
        {
            m_PreviewNode = nodeTarget as UObjectPreviewNode;

            base.Enable();

            m_PreviewNode.onProcessed += OnProcessed;
            onPortConnected += OnPortUpdated;
            onPortDisconnected += OnPortUpdated;

            m_PreviewImage = new Image();
            controlsContainer.Add(m_PreviewImage);

            RefreshPreview();
        }

        public override void Disable()
        {
            m_PreviewNode.onProcessed -= OnProcessed;
            onPortConnected -= OnPortUpdated;
            onPortDisconnected -= OnPortUpdated;

            base.Disable();
        }

        private void OnProcessed()
        {
            RefreshPreview();
        }

        private void OnPortUpdated(PortView portView)
        {
            RefreshPreview();
        }

        private void RefreshPreview()
        {
            if (m_PreviewNode.uObj == null)
            {
                m_PreviewImage.image = null;
            }
            else
            {
                m_PreviewImage.image = AssetPreview.GetAssetPreview(m_PreviewNode.uObj) ?? AssetPreview.GetMiniThumbnail(m_PreviewNode.uObj);
            }
        }
    }
}
