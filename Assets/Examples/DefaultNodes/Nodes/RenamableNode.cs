using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Custom/Renamable")]
public class RenamableNode : BaseNode
{
    [Output("Out")]
	public float		output;
	
    [Input("In")]
	public float		input;

	public override string displayName => "Renamable";

    public override bool isRenamable => true;

	protected override void Process() => output = input;
}