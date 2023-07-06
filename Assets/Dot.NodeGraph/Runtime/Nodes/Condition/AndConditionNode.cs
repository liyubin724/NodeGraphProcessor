using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("And")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/And")]
    public class AndConditionNode : BaseBinaryConditionNode
    {
        protected override void Process()
        {
            output = inputA && inputB;
        }
    }
}
