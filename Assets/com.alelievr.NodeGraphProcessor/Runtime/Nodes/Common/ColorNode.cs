using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Color")]
    [NodeIdentity("Color")]
    public class ColorNode : BaseNode
    {
        [Output(name = "Output"), SerializeField]
        public Color value;
    }
}