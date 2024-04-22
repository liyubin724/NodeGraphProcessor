using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    public abstract class ConverterNode<TFrom, TTo> : BaseNode
    {
        [Input("in")]
        public TFrom input;

        [Output("out")]
        public TTo output;

        protected override void Process()
        {
            OnConvert();
        }

        protected virtual void OnConvert()
        {
            output = (TTo)Convert.ChangeType(input, typeof(TTo));
        }
    }
}
