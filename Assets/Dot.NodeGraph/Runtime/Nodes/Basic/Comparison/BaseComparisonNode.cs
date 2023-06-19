using GraphProcessor;
using System;
using UnityEngine.Rendering;

namespace DotEngine.NodeGraph
{
    public class BaseComparisonNode<TValue> : BaseNode where TValue : IComparable<TValue>
    {
        [Input("In A"), ShowAsDrawer]
        public TValue inA;

        [Input("In B"), ShowAsDrawer]
        public TValue inB;

        [Output("output")]
        public bool compared;

        public CompareFunction compareFunction = CompareFunction.Equal;

        protected override void Process()
        {
            var result = inA.CompareTo(inB);

            switch (compareFunction)
            {
                case CompareFunction.Disabled:
                case CompareFunction.Never: compared = false; break;

                case CompareFunction.Equal: compared = result == 0; break;
                case CompareFunction.NotEqual: compared = result != 0; break;
                case CompareFunction.LessEqual: compared = result <= 0; break;
                case CompareFunction.GreaterEqual: compared = result >= 0; break;
                case CompareFunction.Less: compared = result < 0; break;
                case CompareFunction.Greater: compared = result > 0; break;
                case CompareFunction.Always: compared = true; break;
            }
        }
    }
}
