using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotEngine.NodeGraph.Flow
{
    public abstract class BaseFlowNode : BaseNode
    {
        public virtual IEnumerable<BaseFlowNode> GetNextNodes()
        {
            return GetOutputNodes()
                .Where(n => n is BaseFlowNode)
                .Select(n => n as BaseFlowNode);
        }

        public virtual IEnumerable<BaseNode> GetDependencyNodes()
        {
            return GetInputNodes().Where(n => !(n is BaseFlowNode));
        }
    }

    public abstract class BaseStartFlowNode : BaseFlowNode
    {
        [Output("Next", allowMultiple = true)]
        public FlowLink nextLink;
    }

    public abstract class BaseLinearFlowNode : BaseFlowNode
    {
        [Input("Prev")]
        public FlowLink prevLink;

        public override FieldInfo[] GetNodeFields()
        {
            var fields = base.GetNodeFields();
            Array.Sort(fields, (f1, f2) => f1.Name == nameof(prevLink) ? -1 : 1);
            return fields;
        }
    }
}
