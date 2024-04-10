using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/Vector")]
[NodeIdentity("Vector")]
public class VectorNode : BaseNode
{
    [Output(name = "Out")]
    public Vector4 output;

    [Input(name = "In"), SerializeField]
    public Vector4 input;

    protected override void Process()
    {
        output = input;
    }
}
