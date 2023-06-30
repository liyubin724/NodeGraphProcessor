using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Object To String")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Converter/Object To String")]
    public class ObjectToStringNode : BaseConverterNode<object,string>
    {
        protected override void Process()
        {
            output = input == null?"null":input.ToString();
        }
    }
}
