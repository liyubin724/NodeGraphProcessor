using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/OutputNode")]
[NodeCapability(deletable = false)]
[NodeIdentity("Output Node")]
public class OutputNode : BaseNode
{
    [Input(name = "In")]
    public float input;

    protected override void Process()
    {
        // Do stuff
    }
}
