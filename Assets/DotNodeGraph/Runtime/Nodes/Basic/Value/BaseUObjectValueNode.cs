using GraphProcessor;
using UnityObject = UnityEngine.Object;

namespace DotEngine.NodeGraph
{
    public abstract class BaseUObjectValueNode<TUObject> : BaseValueNode<TUObject>, ICreateNodeFrom<TUObject> where TUObject : UnityObject
    {
        public bool InitializeNodeFromObject(TUObject value)
        {
            this.value = value;
            return true;
        }
    }
}
