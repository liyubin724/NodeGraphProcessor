using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Bool")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Primitive/Bool")]
    public class BoolValueNode : BasePrimitiveValueNode<bool>
    {
    }
}
