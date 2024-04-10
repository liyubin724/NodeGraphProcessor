using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("String")]
[NodeIdentity("String")]
public class StringNode : BaseNode
{
    [Output(name = "Out"), SerializeField]
    public string output;
}
