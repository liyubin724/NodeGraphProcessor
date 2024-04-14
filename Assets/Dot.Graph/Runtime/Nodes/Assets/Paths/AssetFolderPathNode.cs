using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Asset Folder Path", new string[] { "path", "assets" })]
    [NodeMenuItem("Assets/Paths/Folder Path")]
    public class AssetFolderPathNode : AssetPathNode
    {
    }
}
