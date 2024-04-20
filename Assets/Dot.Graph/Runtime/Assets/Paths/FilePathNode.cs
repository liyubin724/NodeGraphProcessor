﻿using GraphProcessor;
using System;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("File Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Path/File Path")]
    public class FilePathNode : PathNode
    {
    }
}
