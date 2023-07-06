using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Or")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/Or")]
    public class OrConditionNode : BaseBinaryConditionNode
    {
        protected override void Process()
        {
            output = inputA || inputB;
        }
    }
}
