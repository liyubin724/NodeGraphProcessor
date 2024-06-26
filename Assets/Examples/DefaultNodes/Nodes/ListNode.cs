﻿using GraphProcessor;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/List")]
[NodeIdentity("List")]
public class ListNode : BaseNode
{
    [Output(name = "Out")]
    public Vector4 output;

    [Input(name = "In"), SerializeField]
    public Vector4 input;

    public List<GameObject> objs = new List<GameObject>();

    protected override void Process()
    {
        output = input;
    }
}
