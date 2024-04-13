using GraphProcessor;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace DotEngine.Graph
{
    public abstract class Comparison<T> : BaseNode where T : IComparable<T>
    {
        [Input]
        [SerializeField]
        public T inA;
        [Input]
        [SerializeField]
        public T inB;

        [Output]
        public bool result;

        public CompareFunction CompareFunction = CompareFunction.Equal;

        protected override void Process()
        {
            switch (CompareFunction)
            {
                case CompareFunction.Disabled:
                case CompareFunction.Never:
                    result = false;
                    break;
                case CompareFunction.Always:
                    result = true;
                    break;
                case CompareFunction.Equal:
                    result = inA.CompareTo(inB) == 0;
                    break;
                case CompareFunction.Greater:
                    result = inA.CompareTo(inB) > 0;
                    break;
                case CompareFunction.Less:
                    result = inA.CompareTo(inB) < 0;
                    break;
                case CompareFunction.GreaterEqual:
                    result = inA.CompareTo(inB) >= 0;
                    break;
                case CompareFunction.LessEqual:
                    result = inA.CompareTo(inB) <= 0;
                    break;
                case CompareFunction.NotEqual:
                    result = inA.CompareTo(inB) != 0;
                    break;
            }
        }
    }

}

