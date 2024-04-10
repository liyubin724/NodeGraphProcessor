using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/FieldTestNode")]
[NodeIdentity("Field Test Node")]
public class FieldTestNode : BaseNode
{
    public string s;
    public int i;
    public float f;
    public Vector2 v2;
    public Vector3 v3;
    public Vector4 v4;
    public LayerMask layer;
    new public Color color;
    public Bounds bounds;
    public Rect rect;
    public CameraClearFlags flags = CameraClearFlags.Color;
    public bool toggle;
    public Gradient gradient;
    public AnimationCurve curve;

    protected override void Process() { }
}
