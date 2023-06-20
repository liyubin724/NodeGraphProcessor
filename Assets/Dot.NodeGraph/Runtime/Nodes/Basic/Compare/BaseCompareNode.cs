using GraphProcessor;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace DotEngine.NodeGraph
{
    public abstract class BaseCompareNode<TIn1,TIn2> : BaseNode
    {
        [Input("In A")]
        public TIn1 inA;

        [Input("In B")]
        public TIn2 inB;

        [Output("result")]
        public bool result;

        protected override void Process()
        {
            result = Compare();
        }

        protected abstract bool Compare();
    }

    
}
