using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Float")]
    [NodeIdentity("Float")]
    public class FloatNode : BaseNode
    {
        [Output("Out"), SerializeField]
        public float output;
    }
}