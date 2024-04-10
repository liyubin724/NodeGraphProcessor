using GraphProcessor;
using UnityEngine;

public enum Setting
{
    S1,
    S2,
    S3,
}

[System.Serializable, NodeMenuItem("Custom/SettingsNode")]
[NodeIdentity("Setting Node")]
public class SettingsNode : BaseNode
{
    public Setting setting;

    [Input]
    public float input;

    [Output]
    public float output;

    protected override void Process() { }
}
