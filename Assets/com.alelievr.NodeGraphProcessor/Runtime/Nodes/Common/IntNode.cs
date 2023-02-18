using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Common/Int")]
[NodeIdentity("Int")]
public class IntNode : BaseNode
{
    [Output("Out"), SerializeField]
    public int output;
}
