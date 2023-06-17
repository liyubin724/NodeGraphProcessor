using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotEngine.NodeGraph.Flow
{
    public abstract class BaseFlowNode : BaseNode,IFlowNode
    {
        [Output("Executed",allowMultiple = true)]
        public FlowLink executed;

        public abstract IEnumerable<IFlowNode> GetExecutedNodes();

        public override FieldInfo[] GetNodeFields()
        {
            var fields = base.GetNodeFields();
            Array.Sort(fields, (f1, f2) => f1.Name == nameof(executed) ? -1 : 1);
            return fields;
        }
    }
}
