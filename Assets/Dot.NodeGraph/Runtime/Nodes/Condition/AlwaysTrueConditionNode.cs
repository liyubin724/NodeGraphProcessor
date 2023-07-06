using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Always True")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/Always True")]
    public class AlwaysTrueConditionNode : BaseConditionNode
    {
        protected override void Process()
        {
            output = true;
        }
    }
}
