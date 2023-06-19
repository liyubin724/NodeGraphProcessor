using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    public abstract class BasePrimitiveValueNode<TValue> : BaseNode
    {
        [Output("output")]
        [SerializeField]
        public TValue value;

        //public override string name
        //{
        //    get
        //    {
        //        var n = GetType().Name;
        //        if (n.EndsWith("ValueNode"))
        //        {
        //            n = n.Substring(0, n.Length - "ValueNode".Length);
        //        }
        //        else if (n.EndsWith("Node"))
        //        {
        //            n = n.Substring(0, n.Length - "Node".Length);
        //        }
        //        return ObjectNames.NicifyVariableName(n);
        //    }
        //}
    }
}
