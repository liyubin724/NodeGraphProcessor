﻿using GraphProcessor;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/TypeSwitchNode")]
[NodeIdentity("TypeSwitchNode")]
public class TypeSwitchNode : BaseNode
{
    [Input]
    public string input;

    [SerializeField]
    public bool toggleType;

    [CustomPortBehavior(nameof(input))]
    IEnumerable<PortData> GetInputPort(List<SerializableEdge> edges)
    {
        yield return new PortData
        {
            identifier = "input",
            displayName = "In",
            displayType = (toggleType) ? typeof(float) : typeof(string)
        };
    }

    protected override void Process()
    {
        Debug.Log("Input: " + input);
    }
}
