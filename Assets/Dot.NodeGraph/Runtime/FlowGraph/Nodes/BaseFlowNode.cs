using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotEngine.NodeGraph.Flow
{
    public abstract class BaseFlowNode : BaseNode, IFlowNode
    {
        public abstract IEnumerable<IFlowNode> GetExecutedNodes();

        public override FieldInfo[] GetNodeFields()
        {
            var fields = base.GetNodeFields();
            Array.Sort(fields, (f1, f2) => f1.Name == "executed" ? -1 : 1);
            return fields;
        }
    }

    public abstract class BaseStartFlowNode : BaseFlowNode
    {
        [Output("Executes", allowMultiple = true)]
        public FlowLink executes;
    }

    public abstract class BaseLinearFlowNode : BaseFlowNode
    {
        [Input("Executed")]
        public FlowLink executed;
    }

    public abstract class EndFlowNode : BaseLinearFlowNode
    {
        public override IEnumerable<IFlowNode> GetExecutedNodes()
        {
            return null;
        }
    }
}
