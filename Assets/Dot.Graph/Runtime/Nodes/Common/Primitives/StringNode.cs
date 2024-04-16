using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("String", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/String")]
    public class StringNode : PrimitiveNode<string>
    {
    }
}
