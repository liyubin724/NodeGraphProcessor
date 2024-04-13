using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Float", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/Float")]
    public class FloatNode : PrimitiveNode<float>
    {
    }
}
