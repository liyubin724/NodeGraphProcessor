using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Display", new string[] { "debug", "common" })]
    [NodeMenuItem("Common/Debug/Display")]
    public class DisplayNode : BaseNode
    {
        [Input]
        public object value;
    }
}
