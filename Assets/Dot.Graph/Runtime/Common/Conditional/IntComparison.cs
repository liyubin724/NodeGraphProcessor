using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Int Comparison", new string[] { "conditional", "common" })]
    [NodeMenuItem("Common/Conditional/Comparison/Int Comparison")]
    public class IntComparison : Comparison<int>
    {
    }
}
