﻿using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Asset Folder Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Folder Path")]
    public class AssetFolderPathNode : AssetPathNode
    {
    }
}
