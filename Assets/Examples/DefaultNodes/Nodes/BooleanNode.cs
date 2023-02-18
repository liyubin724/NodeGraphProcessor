using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Common/Boolean")]
[NodeIdentity("Boolean")]
public class BooleanNode : BaseNode
{
    [Output("output"),SerializeField]
    public bool output;
}
