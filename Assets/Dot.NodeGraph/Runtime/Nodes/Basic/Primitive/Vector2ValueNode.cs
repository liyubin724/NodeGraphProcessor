using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Primitive/Vector2")]
    [Node("Vector2")]
    [NodeTag("basic")]
    public class Vector2ValueNode : BasePrimitiveValueNode<Vector2>
    {
    }
}