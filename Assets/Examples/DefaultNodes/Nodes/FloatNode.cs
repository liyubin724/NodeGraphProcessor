using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Primitives/Float")]
[Node("Float",color = "FF0000",icon = "Icons/SettingsIcons")]
public class FloatNode : BaseNode
{
    [Output("Out")]
	public float		output;
	
    [Input("In")]
	public float		input;

	public override string name => "Float";

	protected override void Process() => output = input;
}