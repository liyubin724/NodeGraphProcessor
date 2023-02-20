using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [NodeMenuItem("Common/Print")]
    [NodeIdentity("Print")]
    public class PrintNode : BaseNode
    {
        [Input]
        public object obj;
    }

    //[NodeMenuItem("Conditional/Print")]
    //[NodeIdentity("Print")]
    //public class ConditionalPrintNode : LinearConditionalNode
    //{
    //	[Input]
    //	public object	obj;
    //}
}