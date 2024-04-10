using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Operations/Sub")]
[NodeIdentity("Sub")]
public class SubNode : BaseNode
{
    [Input(name = "A")]
    public float inputA;
    [Input(name = "B")]
    public float inputB;

    [Output(name = "Out")]
    public float output;

    protected override void Process()
    {
        output = inputA - inputB;
    }
}
