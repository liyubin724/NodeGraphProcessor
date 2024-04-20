using GraphProcessor;

namespace DotEngine.Graph.Assets
{
    public abstract class PathNode : BaseNode
    {
        [Output]
        public string path;
    }
}
