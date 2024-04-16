using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Object To String", new string[] { "converter", "common" })]
    [NodeMenuItem("Common/Converter/Object To String")]
    public class ObjectToStringNode : ConverterNode<object, string>
    {
        protected override void OnConvert()
        {
            output = input?.ToString();
        }
    }
}
