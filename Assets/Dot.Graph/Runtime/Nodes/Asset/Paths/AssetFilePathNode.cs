using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Asset File Path", new string[] { "path", "assets" })]
    [NodeMenuItem("Assets/Paths/File Path")]
    public class AssetFilePathNode : AssetPathNode
    {
    }
}
