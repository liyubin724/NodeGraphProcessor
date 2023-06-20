using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    public abstract class BaseConverterNode<TIn,TOut> : BaseNode
    {
        [Input("In")]
        public TIn input;

        [Output("Output")]
        public TOut output;

        protected override void Process()
        {
            output = (TOut)Convert.ChangeType(input, typeof(TOut));
        }
    }
}
