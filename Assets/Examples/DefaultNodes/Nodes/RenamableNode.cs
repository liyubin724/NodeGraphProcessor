using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Custom/Renamable")]
[NodeCapabilityAttribute(isRenamable = true)]
[Node("Renamable")]
public class RenamableNode : BaseNode
{
    [Output("Out")]
	public float		output;
	
    [Input("In")]
	public float		input;

	protected override void Process() => output = input;
}