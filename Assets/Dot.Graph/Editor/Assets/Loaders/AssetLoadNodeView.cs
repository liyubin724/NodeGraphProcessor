using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(AssetLoadNode))]
    public class AssetLoadNodeView : BaseNodeView
    {
        private AssetLoadNode m_Node;
        private Label m_Label;
        private Image m_PreviewImage;

        public override void Enable()
        {
            m_Node = nodeTarget as AssetLoadNode;

            m_Label = new Label();
            controlsContainer.Add(m_Label);

            m_PreviewImage = new Image();
            controlsContainer.Add(m_PreviewImage);

            nodeTarget.onProcessed += () =>
            {
                UpdateAsset(m_Node.asset);
            };
            onPortConnected += (port) =>
            {
                if (port.fieldName == nameof(AssetLoadNode.assetPath))
                {
                    nodeTarget.OnProcess();
                }
            };
            onPortDisconnected += (port) =>
            {
                if (port.fieldName == nameof(AssetLoadNode.assetPath))
                {
                    m_Node.asset = null;
                    UpdateAsset(null);
                }
            };

            UpdateAsset(m_Node.asset);
        }

        private void UpdateAsset(UnityObject obj)
        {
            if (obj != null)
            {
                m_Label.text = obj.ToString();

#if UNITY_EDITOR
                m_PreviewImage.image = AssetPreview.GetAssetPreview(obj) ?? AssetPreview.GetMiniThumbnail(obj);
#endif
            }
            else
            {
                m_Label.text = string.Empty;
                m_PreviewImage.image = null;
            }

        }
    }
}
