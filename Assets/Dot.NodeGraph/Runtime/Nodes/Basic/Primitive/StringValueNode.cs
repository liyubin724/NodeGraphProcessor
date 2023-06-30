using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("String")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Primitive/String")]
    public class StringValueNode : BasePrimitiveValueNode<string>
    {
    }
}
