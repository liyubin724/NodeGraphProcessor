using GraphProcessor;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace DotEngine.NodeGraph
{
    public abstract class BaseUObjectValueNode<TUObject> : BaseNode, ICreateNodeFrom<TUObject> where TUObject : UnityObject
    {
        [Output("output")]
        [SerializeField]
        public TUObject value;

        public bool InitializeNodeFromObject(TUObject value)
        {
            this.value = value;
            return true;
        }
    }
}
