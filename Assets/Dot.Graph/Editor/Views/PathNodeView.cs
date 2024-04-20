using DotEngine.Graph;
using GraphProcessor;
using UnityEngine.UIElements;

namespace DotEditor.Graph
{
    public abstract class PathNodeView : BaseNodeView
    {
        private PathNode m_PathNode;

        private TextField m_PathField;

        public override void Enable()
        {
            m_PathNode = nodeTarget as PathNode;

            var selectFolderContainer = new VisualElement();
            selectFolderContainer.style.flexDirection = FlexDirection.Row;

            m_PathField = new TextField("Path");
            m_PathField.value = m_PathNode.path;
            m_PathField.RegisterValueChangedCallback(evt =>
            {
                m_PathNode.path = evt.newValue;
            });
            selectFolderContainer.Add(m_PathField);

            var browseBtn = new Button(() =>
            {
                var path = OpenPathPanel(m_PathNode.path);
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
