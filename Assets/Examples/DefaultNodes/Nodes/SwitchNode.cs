using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Conditional/Switch")]
[NodeIdentity("Switch")]
public class SwitchNode : BaseNode
{
    [Input(name = "In")]
    public float input;

    [Output(name = "Out")]
    public float output;

    protected override void Process()
    {
        output = input * 42;
    }
}
