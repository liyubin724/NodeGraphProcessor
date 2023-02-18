using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Common/Float")]
[NodeIdentity("Float")]
public class FloatNode : BaseNode
{
    [Output("Out"), SerializeField]
    public float output;
}