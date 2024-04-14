using DotEngine.Graph;
using GraphProcessor;
using UnityEngine;
using UnityEngine.UIElements;

namespace DotEditor.Graph
{
    public abstract class AssetPathNodeView : BaseNodeView
    {
        private string m_AssetPath = Application.dataPath.Replace("\\", "/");

        private AssetPathNode m_PathNode;

        private TextField m_PathField;

        public override void Enable()
        {
            m_PathNode = nodeTarget as AssetPathNode;

            var selectFolderContainer = new VisualElement();
            selectFolderContainer.style.flexDirection = FlexDirection.Row;

            m_PathField = new TextField("File");
            m_PathField.value = m_PathNode.path;
            selectFolderContainer.Add(m_PathField);

            var browseBtn = new Button(() =>
            {
#if UNITY_EDITOR
                var path = OpenPathPanel(m_AssetPath);
                if (!string.IsNullOrEmpty(path))
                {
                    path = path.Replace("\\", "/");
                    path = path.Replace(m_AssetPath, "Assets");

                    m_PathField.value = path;
                    m_PathNode.path = path;
                }
#endif
            });
            browseBtn.text = "Browse";
            selectFolderContainer.Add(browseBtn);

            controlsContainer.Add(selectFolderContainer);
        }

        protected abstract string OpenPathPanel(string fullPath);
    }
}
