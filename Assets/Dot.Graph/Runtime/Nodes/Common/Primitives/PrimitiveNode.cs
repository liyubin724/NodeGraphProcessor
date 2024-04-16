using GraphProcessor;
using UnityEngine;

namespace DotEngine.Graph
{
    public abstract class PrimitiveNode<T> : BaseNode
    {
        [Output]
        [SerializeField]
        public T value;
    }
}
