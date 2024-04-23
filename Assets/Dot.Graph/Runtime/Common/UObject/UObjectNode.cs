using GraphProcessor;

namespace DotEngine.Graph
{
    public abstract class UObjectNode<TUObject> : PrimitiveNode<TUObject>, ICreateNodeFrom<TUObject> where TUObject : UnityEngine.Object
    {
        public bool InitializeNodeFromObject(TUObject value)
        {
            this.value = value;
            return true;
        }
    }
}
