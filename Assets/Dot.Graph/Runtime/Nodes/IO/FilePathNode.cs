using GraphProcessor;
using System;

namespace DotEngine.Graph.IO
{
    [Serializable]
    [NodeIdentity("File Path", new string[] { "io", "path" })]
    [NodeMenuItem("IO/Path/File Path")]
    public class FilePathNode : PathNode
    {
    }
}
