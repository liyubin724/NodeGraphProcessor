using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Primitive/Float")]
    [Node("Float")]
    [NodeTag("basic")]
    public class FloatValueNode : BasePrimitiveValueNode<float>
    {
    }
}
