using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Not")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/Not")]
    public class NotConditionNode : BaseUnaryConditionNode
    {
        protected override void Process()
        {
            output = !input;
        }
    }
}
