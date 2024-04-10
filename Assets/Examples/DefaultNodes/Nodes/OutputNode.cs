using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/OutputNode")]
[NodeCapability(deletable = false)]
public class OutputNode : BaseNode
{
    [Input(name = "In")]
    public float input;

    public override string name => "OutputNode";

    protected override void Process()
    {
        // Do stuff
    }
}
