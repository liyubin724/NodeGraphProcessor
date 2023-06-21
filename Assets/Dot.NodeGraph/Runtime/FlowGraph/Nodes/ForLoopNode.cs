using GraphProcessor;
using System.Collections.Generic;
using System.Linq;

namespace DotEngine.NodeGraph.Flow
{
    public class ForLoopNode : BaseLinearFlowNode
    {
        [Output("Loop")]
        public FlowLink loopBody;

        [Output("Complete")]
        public FlowLink completeBody;

        public int start = 0;
        public int end = 10;

        [Output("Index")]
        public int index = 0;

        protected override void Process()
        {
            index++;
        }

        public override IEnumerable<BaseFlowNode> GetNextNodes()
        {
            return null;
        }

        public IEnumerable<BaseFlowNode> GetExecutedLoopBody()
        {
            return outputPorts.FirstOrDefault(n => n.fieldName == nameof(loopBody))
            .GetEdges().Select(e => e.inputNode as BaseFlowNode);
        }

        public IEnumerable<BaseFlowNode> GetExecutedCompletedBody()
        {
            return outputPorts.FirstOrDefault(n => n.fieldName == nameof(completeBody))
            .GetEdges().Select(e => e.inputNode as BaseFlowNode);
        }
    }
}
