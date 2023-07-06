using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Any Of")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/Any Of")]
    public class AnyOfConditionNode : BaseComplexConditionNode
    {
        protected override void Process()
        {
            foreach(var result in conditions)
            {
                if (result)
                {
                    output = true;
                    return;
                }
            }

            output = false;
        }
    }
}
