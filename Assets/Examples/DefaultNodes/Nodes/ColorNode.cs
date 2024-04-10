using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Primitives/Color")]
[NodeIdentity("Color")]
public class ColorNode : BaseNode
{
    [Output(name = "Color"), SerializeField]
    new public Color color;
}
