using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using NodeGraphProcessor.Examples;

[NodeMenuItem("Print")]
[NodeName("Print")]
public class PrintNode : BaseNode
{
	[Input]
	public object	obj;
}

[NodeMenuItem("Conditional/Print")]
[NodeName("Print")]
public class ConditionalPrintNode : LinearConditionalNode
{
	[Input]
	public object	obj;
}
