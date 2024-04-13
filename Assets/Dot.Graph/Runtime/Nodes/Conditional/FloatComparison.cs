using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Float Comparison", new string[] { "conditional", "common" })]
    [NodeMenuItem("Common/Conditional/Comparison/Float Comparison")]
    public class FloatComparison : Comparison<float>
    {
    }
}
