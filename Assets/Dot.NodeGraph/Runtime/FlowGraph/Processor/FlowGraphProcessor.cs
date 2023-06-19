using GraphProcessor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DotEngine.NodeGraph.Flow
{
    public class FlowGraphProcessor : BaseGraphProcessor
    {
        private List<StartFlowNode> startNodes;

        public FlowGraphProcessor(BaseGraph graph) : base(graph)
        {
        }

        public override void UpdateComputeOrder()
        {
            startNodes = graph.nodes.Where(n => n is StartFlowNode)
                                    .Select(n => n as StartFlowNode)
                                    .ToList();
        }

        public override void Run()
        {
            if (startNodes.Count > 0)
            {

            }
        }
    }
}
