﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("String")]
[NodeIdentity("String")]
public class StringNode : BaseNode
{
	[Output(name = "Out"), SerializeField]
	public string				output;
}
