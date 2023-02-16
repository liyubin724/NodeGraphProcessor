using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Custom/InheritanceBase")]
[NodeName("InheritanceBase")]
public class InheritanceBase : BaseNode
{
	[Input(name = "In Base")]
    public float                input;

	[Output(name = "Out Base")]
	public float				output;

	public float				fieldBase;

	protected override void Process()
	{
	    output = input * 42;
	}
}
