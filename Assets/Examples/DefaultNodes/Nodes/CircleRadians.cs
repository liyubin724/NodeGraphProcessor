﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Custom/CircleRadians")]
[NodeIdentity("CircleRadians")]
public class CircleRadians : BaseNode
{
	[Output(name = "In")]
    public List< float >		outputRadians;

	[CustomPortOutput(nameof(outputRadians), typeof(float))]
	public void PushOutputRadians(List< SerializableEdge > connectedEdges)
	{
		int i = 0;

		// outputRadians should match connectedEdges length, the list is generated by the editor function

		foreach (var edge in connectedEdges)
		{
			edge.passThroughBuffer = outputRadians[i];
			i++;
		}
	}
}
