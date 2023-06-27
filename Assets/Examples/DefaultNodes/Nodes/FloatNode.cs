using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Primitives/Float")]
public class FloatNode : BaseNode
{
    [Output("Out")]
	public float		output;
	
    [Input("In")]
	public float		input;

	public override string displayName => "Float";

	protected override void Process() => output = input;
}