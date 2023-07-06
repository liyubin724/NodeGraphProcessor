using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("All Of")]
    [NodeTag("condition")]
    [NodeMenuItem("Conditions/All Of")]
    public class AllOfConditionNode : BaseComplexConditionNode
    {
        protected override void Process()
        {
            foreach(var result in conditions)
            {
                if(!result)
                {
                    output = false; 
                    return;
                }
            }

            output = true;
        }
    }
}
