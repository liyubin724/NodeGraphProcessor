﻿using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Asset File Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/File Path")]
    public class AssetFilePathNode : AssetPathNode
    {
    }
}
