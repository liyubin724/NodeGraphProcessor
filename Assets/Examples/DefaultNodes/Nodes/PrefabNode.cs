using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/Prefab")]
[NodeIdentity("Prefab Node")]
public class PrefabNode : BaseNode
{
    [Output(name = "Out"), SerializeField]
    public GameObject output;
}
