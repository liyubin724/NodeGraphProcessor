using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Bool", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/Bool")]
    public class BoolNode : PrimitiveNode<bool>
    {
    }
}
