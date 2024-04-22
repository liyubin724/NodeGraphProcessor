using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Bool Comparison", new string[] { "conditional", "common" })]
    [NodeMenuItem("Common/Conditional/Comparison/Bool Comparison")]
    public class BoolComparison : Comparison<bool>
    {
    }
}
