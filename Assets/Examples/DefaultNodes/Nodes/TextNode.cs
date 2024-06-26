﻿using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Primitives/Text")]
[NodeIdentity("Text")]
public class TextNode : BaseNode
{
    [Output(name = "Label"), SerializeField]
    public string output;
}
