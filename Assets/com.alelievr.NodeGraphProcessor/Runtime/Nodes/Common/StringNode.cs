﻿using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Common/String")]
[NodeIdentity("String")]
public class StringNode : BaseNode
{
	[Output(name = "Out"), SerializeField]
	public string				output;
}