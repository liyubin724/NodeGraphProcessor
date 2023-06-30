using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("String To Float")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Converter/String To Float")]
    public class StringToFloatNode : BaseConverterNode<string,float>
    {
    }
}
