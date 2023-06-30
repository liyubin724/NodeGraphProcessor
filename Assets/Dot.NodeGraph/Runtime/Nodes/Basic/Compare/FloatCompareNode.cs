using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Compare(Float)")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Compare/Compare(Float)")]
    public class FloatCompareNode : BaseCompareValueNode<float>
    {
    }
}
