using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Custom/OutputNode")]
[NodeCapability(isDeletable = false)]
[NodeName("OutputNode")]
public class OutputNode : BaseNode
{
	[Input(name = "In")]
    public float                input;

	protected override void Process()
	{
		// Do stuff
	}
}
