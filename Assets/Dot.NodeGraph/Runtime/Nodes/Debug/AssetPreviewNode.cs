using GraphProcessor;
using System;
using UnityObject = UnityEngine.Object;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Asset Preview")]
    [NodeTag("debug")]
    [NodeMenuItem("Debug/Asset Preview")]
    public class AssetPreviewNode : BaseNode
    {
        [Input("Asset")]
        public UnityObject asset;
    }
}
