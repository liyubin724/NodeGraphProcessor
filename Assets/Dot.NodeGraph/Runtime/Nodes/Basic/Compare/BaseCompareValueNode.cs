using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    public enum CompareFunction
    {
        Never = 1,
        Less = 2,
        Equal = 3,
        LessEqual = 4,
        Greater = 5,
        NotEqual = 6,
        GreaterEqual = 7,
        Always = 8
    }

    public abstract class BaseCompareValueNode<TValue> : BaseCompareNode<TValue, TValue> where TValue : IComparable<TValue>
    {
        public CompareFunction compareFunction = CompareFunction.Equal;

        protected override bool Compare()
        {
            var result = inA.CompareTo(inB);

            switch (compareFunction)
            {
                case CompareFunction.Never: return false;

                case CompareFunction.Less: return result < 0;
                case CompareFunction.Equal: return result == 0;
                case CompareFunction.LessEqual: return result <= 0;
                case CompareFunction.Greater: return result > 0;
                case CompareFunction.NotEqual: return result != 0;
                case CompareFunction.GreaterEqual: return result >= 0;

                case CompareFunction.Always: return true;
            }

            return false;
        }
    }
}
