using GraphProcessor;

namespace DotEngine.Graph.Assets
{
    public abstract class FilterNode : BaseNode
    {
        [Input]
        public string[] input;

        [Output]
        public string[] output;
    }
}
