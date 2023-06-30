using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotEngine.NodeGraph.Flow
{
    [Serializable]
    [NodeMenuItem("Flow/Conditions/IF")]
    [Node("If")]
    [NodeTag("flow")]
    public class IfNode : BaseLinearFlowNode
    {
        [Input(name = "Condition")]
        public bool condition;

        [Output(name = "True")]
        public FlowLink @true;

        [Output(name = "False")]
        public FlowLink @false;

        public override IEnumerable<BaseFlowNode> GetNextNodes()
        {
            string name = condition ? nameof(@true) : nameof(@false);

            return outputPorts.FirstOrDefault(n => n.fieldName == name).GetEdges().Select(e => e.inputNode as BaseFlowNode);
        }
    }
}
