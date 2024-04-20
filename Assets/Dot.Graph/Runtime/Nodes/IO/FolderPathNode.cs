using GraphProcessor;
using System;

namespace DotEngine.Graph.IO
{
    [Serializable]
    [NodeIdentity("Folder Path", new string[] { "io", "path" })]
    [NodeMenuItem("IO/Path/Folder Path")]
    public class FolderPathNode : PathNode
    {
    }
}

