using GraphProcessor;
using UnityEngine;
using UnityObject = UnityEngine.Object;

[System.Serializable, NodeMenuItem("Common/Unity Object")]
[NodeIdentity("Unity Object")]
public class UnityObjectNode : BaseNode
{
    [Output("Out"), SerializeField]
    public UnityObject output;
}
