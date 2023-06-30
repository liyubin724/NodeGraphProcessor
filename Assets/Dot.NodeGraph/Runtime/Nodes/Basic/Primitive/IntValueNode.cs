using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Primitive/Int")]
    [Node("Int")]
    [NodeTag("basic")]
    public class IntValueNode : BasePrimitiveValueNode<int>
    {
    }
}
