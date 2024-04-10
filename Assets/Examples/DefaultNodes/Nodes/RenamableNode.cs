using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Custom/Renamable")]
[NodeCapability(renamable = true)]
public class RenamableNode : BaseNode
{
    [Output("Out")]
    public float output;

    [Input("In")]
    public float input;

    public override string name => "Renamable";

    protected override void Process() => output = input;
}