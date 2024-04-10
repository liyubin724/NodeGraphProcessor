using System.Collections.Generic;
using System.Linq;

namespace GraphProcessor.Examples
{
    [System.Serializable, NodeMenuItem("Conditional/Start")]
    [NodeIdentity("Start")]
    public class StartNode : BaseNode, IConditionalNode
    {
        [Output(name = "Executes")]
        public ConditionalLink executes;

        public IEnumerable<ConditionalNode> GetExecutedNodes()
        {
            // Return all the nodes connected to the executes port
            return GetOutputNodes().Where(n => n is ConditionalNode).Select(n => n as ConditionalNode);
        }
    }
}
