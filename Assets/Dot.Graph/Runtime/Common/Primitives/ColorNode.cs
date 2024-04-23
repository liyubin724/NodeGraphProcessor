using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Color", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/Color")]
    public class ColorNode : PrimitiveNode<Color>
    {
    }
}
