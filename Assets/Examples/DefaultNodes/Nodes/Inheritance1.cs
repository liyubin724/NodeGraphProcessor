using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/Inheritance1")]
[NodeIdentity("Inheritance1")]
public class Inheritance1 : InheritanceBase
{
    [Input(name = "In 1")]
    public float input1;

    [Output(name = "Out 1")]
    public float output1;

    public float field1;

    protected override void Process()
    {
        output = input * 42;
    }
}
