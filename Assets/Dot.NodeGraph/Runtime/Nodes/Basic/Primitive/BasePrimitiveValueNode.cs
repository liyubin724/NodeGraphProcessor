using GraphProcessor;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    public abstract class BasePrimitiveValueNode<TValue> : BaseNode
    {
        [Output("output")]
        [SerializeField]
        public TValue value;
    }
}
