using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Int")]
    [NodeIdentity("Int")]
    public class IntNode : BaseNode
    {
        [Output("Out"), SerializeField]
        public int output;
    }
}