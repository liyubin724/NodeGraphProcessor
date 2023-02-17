using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Custom/Vertical")]
[NodeIdentity("Vertical")]
public class VerticalNode : BaseNode
{
	[Input, Vertical]
    public float                input;

	[Output, Vertical]
	public float				output;
	[Output, Vertical]
	public float				output2;
	[Output, Vertical]
	public float				output3;

	protected override void Process()
	{
	    output = input * 42;
	}
}
