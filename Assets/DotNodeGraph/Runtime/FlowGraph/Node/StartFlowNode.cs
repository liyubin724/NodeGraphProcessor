using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotEngine.NodeGraph.Flow
{
    [Serializable]
    [NodeMenuItem("Flow/Start")]
    public class StartFlowNode : BaseNode, IFlowNode
    {
        [Output(name = "Executes")]
        public FlowLink executes;

        public override string name => "Start";

        public IEnumerable<IFlowNode> GetExecutedNodes()
        {
            return GetOutputNodes().Where(n => n is IFlowNode).Select(n => n as IFlowNode);
        }

        public override FieldInfo[] GetNodeFields()
        {
            return base.GetNodeFields();
        }
    }
}
