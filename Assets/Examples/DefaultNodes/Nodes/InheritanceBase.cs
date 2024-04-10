using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/InheritanceBase")]
[NodeIdentity("Inheritance Base")]
public class InheritanceBase : BaseNode
{
    [Input(name = "In Base")]
    public float input;

    [Output(name = "Out Base")]
    public float output;

    public float fieldBase;

    protected override void Process()
    {
        output = input * 42;
    }
}
