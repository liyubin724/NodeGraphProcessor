using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Texture2D")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Unity Object/Texture 2D")]
    public class Texture2DValueNode : BaseUObjectValueNode<Texture2D>
    {
    }
}
