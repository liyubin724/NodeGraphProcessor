﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Operations/Sub")]
[NodeName("Sub")]
public class SubNode : BaseNode
{
	[Input(name = "A")]
    public float                inputA;
	[Input(name = "B")]
    public float                inputB;

	[Output(name = "Out")]
	public float				output;

	protected override void Process()
	{
	    output = inputA - inputB;
	}
}
