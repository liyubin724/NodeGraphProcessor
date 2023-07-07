using GraphProcessor;
using System.Collections.Generic;

namespace DotEngine.NodeGraph
{
    public abstract class BaseConditionNode : BaseNode
    {
        [Output("Output")]
        public bool output;
    }

    public abstract class BaseUnaryConditionNode : BaseConditionNode
    {
        [Input("Input")]
        public bool input;
    }

    public abstract class BaseBinaryConditionNode : BaseConditionNode
    {
        [Input("Input A")]
        public bool inputA;
        [Input("Input B")]
        public bool inputB;
    }

    public abstract class BaseComplexConditionNode : BaseConditionNode
    {
        [Input]
        public List<bool> conditions;

        [CustomPortBehavior(nameof(conditions))]
        public IEnumerable<PortData> ListDependencies(List<SerializableEdge> edges)
        {
            for (int i = 0; i < edges.Count + 1; i++)
            {
                yield return new PortData
                {
                    displayName = "Input " + i,
                    displayType = typeof(bool),
                    identifier = i.ToString(),
                };
            }
        }
    }
}
