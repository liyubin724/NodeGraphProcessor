using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Primitives/Float")]
[NodeIdentity("Float")]
public class FloatNode : BaseNode
{
    [Output("Out")]
    public float output;

    [Input("In")]
    public float input;

    protected override void Process() => output = input;
}