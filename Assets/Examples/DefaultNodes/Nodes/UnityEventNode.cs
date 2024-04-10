using UnityEngine;
using GraphProcessor;
using UnityEngine.Events;

[System.Serializable, NodeMenuItem("Custom/Unity Event Node")]
[NodeIdentity("Unity Event Node")]
public class UnityEventNode : BaseNode
{
    [Input(name = "In")]
    public float input;

    [Output(name = "Out")]
    public float output;

    public UnityEvent evt;

    protected override void Process()
    {
        output = input * 42;
    }
}
