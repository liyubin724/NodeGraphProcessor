using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Common/Color")]
[NodeIdentity("Color")]
public class ColorNode : BaseNode
{
    [Output(name = "Output"), SerializeField]
    public Color value;
}
