using GraphProcessor;
using System;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("File Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Paths/File Path")]
    public class AssetFilePathNode : AssetPathNode
    {
    }
}
