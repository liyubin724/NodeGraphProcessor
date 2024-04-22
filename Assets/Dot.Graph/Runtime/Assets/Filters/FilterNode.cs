using GraphProcessor;

namespace DotEngine.Graph.Assets
{
    public abstract class FilterNode : BaseNode
    {
        [Input]
        public string[] inputAssets;

        [Output]
        public string[] outputAssets;
    }
}
