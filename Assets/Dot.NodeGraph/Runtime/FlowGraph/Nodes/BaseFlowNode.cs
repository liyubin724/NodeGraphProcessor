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

        public BaseNode[] GetAllDependencies()
        {
            Stack<BaseNode> dependencyStack = new Stack<BaseNode>();
            dependencyStack.Push(this);

            List<BaseNode> dependencies = new List<BaseNode>();
            while (dependencyStack.Count > 0)
            {
                var node = dependencyStack.Pop();

                if (node is BaseFlowNode)
                {
                    continue;
                }
                dependencies.Insert(0, node);

                foreach (var dep in node.GetInputNodes())
                {
                    dependencyStack.Push(dep);
                }
            }

            return dependencies.ToArray();
        }

        public void OnExecute()
        {
            ProcessDependencies();

            OnProcess();

            foreach (var nextNode in GetNextNodes())
            {
                nextNode.OnExecute();
            }
        }

        protected virtual void ProcessDependencies()
        {
            var dependencies = GetAllDependencies();

            HashSet<BaseNode> processedNodeSet = new HashSet<BaseNode>();
            foreach (var dep in dependencies)
            {
                if (!processedNodeSet.Contains(dep))
                {
                    dep.OnProcess();

                    processedNodeSet.Add(dep);
                }
            }
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
