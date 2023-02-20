using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Boolean")]
    [NodeIdentity("Boolean")]
    public class BooleanNode : BaseNode
    {
        [Output("output"), SerializeField]
        public bool output;
    }
}
