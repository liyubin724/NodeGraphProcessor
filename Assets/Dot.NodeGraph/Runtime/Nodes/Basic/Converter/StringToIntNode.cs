using GraphProcessor;
using System;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Converter/String To Int")]
    public class StringToIntNode : BaseConverterNode<string,int>
    {
    }
}
