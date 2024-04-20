using DotEngine.Graph.IO;
using GraphProcessor;
using UnityEditor;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(FolderPathNode))]
    public class FolderPathNodeView : PathNodeView
    {
        protected override string OpenPathPanel(string path)
        {
            return EditorUtility.OpenFolderPanel("Open File", path, null);
        }
    }
}

