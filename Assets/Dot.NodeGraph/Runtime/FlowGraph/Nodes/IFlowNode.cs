using System.Collections.Generic;
using System.Reflection;

namespace DotEngine.NodeGraph.Flow
{
    public interface IFlowNode
    {
        IEnumerable<IFlowNode> GetExecutedNodes();

        FieldInfo[] GetNodeFields();
    }
}
