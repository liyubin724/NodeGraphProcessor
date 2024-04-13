using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("String Comparison", new string[] { "conditional", "common" })]
    [NodeMenuItem("Common/Conditional/Comparison/String Comparison")]
    public class StringComparison : Comparison<string>
    {
    }
}
