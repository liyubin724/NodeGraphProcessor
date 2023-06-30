using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("String To Int")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Converter/String To Int")]
    public class StringToIntNode : BaseConverterNode<string,int>
    {
    }
}
