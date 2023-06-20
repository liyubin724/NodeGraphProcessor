using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Converter/String To Float")]
    public class StringToFloatNode : BaseConverterNode<string,float>
    {
    }
}
