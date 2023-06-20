using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Compare/Equal")]
    internal class EqualCompareNode : BaseCompareNode<object,object>
    {
        protected override bool Compare()
        {
            if(inA == null && inB == null)
            {
                return true;
            }else if(inA == null || inB == null)
            {
                return false;
            }
            else
            {
                return inA.Equals(inB);
            }
        }
    }
}
