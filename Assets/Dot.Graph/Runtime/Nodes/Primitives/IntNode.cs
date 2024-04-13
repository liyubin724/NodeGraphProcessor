using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Int", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/Int")]
    public class IntNode : PrimitiveNode<int>
    {
    }
}
