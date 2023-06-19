using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotEngine.NodeGraph.Flow
{
    [Serializable]
    [NodeMenuItem("Flow/Start")]
    public class StartFlowNode : BaseStartFlowNode
    {
        public override string name => "Start";

        public override IEnumerable<IFlowNode> GetExecutedNodes()
        {
            return GetOutputNodes().Where(n => n is IFlowNode).Select(n => n as IFlowNode);
        }
    }
}
