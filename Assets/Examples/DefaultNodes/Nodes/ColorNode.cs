﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Primitives/Color")]
[NodeIdentity("Color")]
public class ColorNode : BaseNode
{
	[Output(name = "Color"), SerializeField]
	new public Color				color;
}
