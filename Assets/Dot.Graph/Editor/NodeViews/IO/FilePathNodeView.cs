using DotEngine.Graph.IO;
using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace DotEditor.Graph.IO
{
    [CustomNodeEditor(typeof(FilePathNode))]
    public class FilePathNodeView : PathNodeView
    {
        protected override string OpenPathPanel(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Application.dataPath;
            }

            return EditorUtility.OpenFilePanel("Open File", path, null);
        }
    }
}
