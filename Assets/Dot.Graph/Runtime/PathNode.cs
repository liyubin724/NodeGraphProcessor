using GraphProcessor;

namespace DotEngine.Graph
{
    public abstract class PathNode : BaseNode
    {
        [Output]
        public string path;
    }
}
