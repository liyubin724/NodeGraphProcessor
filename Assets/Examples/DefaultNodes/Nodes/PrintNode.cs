using GraphProcessor;
using GraphProcessor.Examples;
using UnityEngine;

[NodeMenuItem("Print")]
[NodeIdentity("Print")]
public class PrintNode : BaseNode
{
    [Input]
    public object obj;
}

[NodeMenuItem("Conditional/Print")]
[NodeIdentity("Print")]
public class ConditionalPrintNode : LinearConditionalNode
{
    [Input]
    public object obj;
}
