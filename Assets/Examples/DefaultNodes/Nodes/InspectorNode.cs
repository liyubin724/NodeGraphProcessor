using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/InspectorNode")]
[NodeIdentity("Inspector Node")]
[NodeCapability(needInspector = true)]
public class InspectorNode : BaseNode
{
    [Input(name = "In")]
    public float input;

    [Output(name = "Out")]
    public float output;

    [ShowInInspector]
    public bool additionalSettings;
    [ShowInInspector]
    public string additionalParam;

    protected override void Process()
    {
        output = input * 42;
    }
}
