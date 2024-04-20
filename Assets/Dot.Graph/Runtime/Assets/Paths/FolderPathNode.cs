﻿using GraphProcessor;
using System;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Folder Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Path/Folder Path")]
    public class FolderPathNode : PathNode
    {
    }
}
