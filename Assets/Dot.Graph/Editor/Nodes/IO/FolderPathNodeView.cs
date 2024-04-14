using DotEngine.Graph;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(FolderPathNode))]
    public class FolderPathNodeView : BaseNodeView
    {
        private string m_AssetPath = Application.dataPath.Replace("\\", "/").Replace("/Assets", "/");

        private FolderPathNode m_Node;

        private TextField m_PathField;
        private Toggle m_RelativeToAssets;

        public override void Enable()
        {
            m_Node = nodeTarget as FolderPathNode;

            m_RelativeToAssets = new Toggle("In Assets");
            m_RelativeToAssets.value = m_Node.isRelativeToAssets;

            var selectFolderContainer = new VisualElement();
            selectFolderContainer.style.flexDirection = FlexDirection.Row;

            m_PathField = new TextField("Folder");
            m_PathField.value = m_Node.path;
            selectFolderContainer.Add(m_PathField);

            var browseBtn = new Button(() =>
            {
                var path = EditorUtility.OpenFolderPanel("Folder", m_Node.path, null);
                if (!string.IsNullOrEmpty(path))
                {
                    SetPath(path);
                }
            });
            browseBtn.text = "Browse";
            selectFolderContainer.Add(browseBtn);

            controlsContainer.Add(selectFolderContainer);
            controlsContainer.Add(m_RelativeToAssets);
        }

        private void SetPath(string path)
        {
            path = path.Replace("\\", "/");
            if (m_Node.isRelativeToAssets)
            {
                path = path.Replace(m_AssetPath, "");
                if (!path.StartsWith("Assets"))
                {
                    path = "Assets";
                }
            }

            m_PathField.SetValueWithoutNotify(path);
            m_Node.path = path;
        }
    }
}

