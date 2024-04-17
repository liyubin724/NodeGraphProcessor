using DotEngine.Graph;
using GraphProcessor;
using UnityEngine.UIElements;

namespace DotEditor.Graph
{
    public abstract class AssetPathNodeView : BaseNodeView
    {
        private AssetPathNode m_PathNode;

        private TextField m_PathField;

        public override void Enable()
        {
            m_PathNode = nodeTarget as AssetPathNode;

            var selectFolderContainer = new VisualElement();
            selectFolderContainer.style.flexDirection = FlexDirection.Row;

            m_PathField = new TextField("File");
            m_PathField.value = m_PathNode.assetPath;
            m_PathField.RegisterValueChangedCallback(evt =>
            {
                m_PathNode.assetPath = evt.newValue;
            });
            selectFolderContainer.Add(m_PathField);

            var browseBtn = new Button(() =>
            {
                var path = OpenPathPanel(m_PathNode.assetPath);
                if (string.IsNullOrEmpty(path))
                {
                    return;
                }

                m_PathField.value = path;
            });
            browseBtn.text = "Browse";
            selectFolderContainer.Add(browseBtn);

            controlsContainer.Add(selectFolderContainer);
        }

        protected abstract string OpenPathPanel(string assetPath);
    }
}
