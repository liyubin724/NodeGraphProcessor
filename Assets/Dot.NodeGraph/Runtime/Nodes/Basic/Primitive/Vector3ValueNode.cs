using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Primitive/Vector3")]
    [Node("Vector3")]
    [NodeTag("basic")]
    public class Vector3ValueNode : BasePrimitiveValueNode<Vector3>
    {
    }
}
