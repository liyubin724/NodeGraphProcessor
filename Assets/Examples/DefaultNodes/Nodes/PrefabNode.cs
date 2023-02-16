using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Custom/Prefab")]
[NodeName("Prefab")]
public class PrefabNode : BaseNode
{
	[Output(name = "Out"), SerializeField]
	public GameObject			output;
}
