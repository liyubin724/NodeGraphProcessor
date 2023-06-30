using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Primitive/Color")]
    [Node("Color")]
    [NodeTag("basic")]
    public class ColorValueNode : BasePrimitiveValueNode<Color>
    {
    }
}
