using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Always Flase")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/Always Flase")]
    public class AlwaysFalseConditionNode : BaseConditionNode
    {
        protected override void Process()
        {
            output = false;
        }
    }
}
