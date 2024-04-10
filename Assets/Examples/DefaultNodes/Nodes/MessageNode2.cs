using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/MessageNode2")]
[NodeIdentity("Message Node2")]
public class MessageNode2 : BaseNode
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
