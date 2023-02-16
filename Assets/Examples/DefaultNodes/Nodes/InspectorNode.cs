using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Custom/InspectorNode")]
[NodeName("InspectorNode")]
public class InspectorNode : BaseNode
{
	[Input(name = "In")]
    public float                input;

	[Output(name = "Out")]
	public float				output;

	[ShowInInspector]
	public bool additionalSettings;
	[ShowInInspector]
	public string additionalParam;

	protected override void Process()
	{
	    output = input * 42;
	}
}
