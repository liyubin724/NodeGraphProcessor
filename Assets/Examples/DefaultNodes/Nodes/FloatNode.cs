using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;

[System.Serializable, NodeMenuItem("Common/Float")]
[NodeIdentity("Float")]
public class FloatNode : BaseNode
{
    [Output("Out"), SerializeField]
	public float		output;
}