using GraphProcessor;
using UnityObject = UnityEngine.Object;

namespace DotEngine.Graph
{
    public abstract class AssetLoadNode : BaseNode
    {
        [Input]
        public string assetPath;

        [Output]
        public UnityObject asset;

        protected override void Process()
        {
            asset = LoadAsset(assetPath);
        }

        protected abstract UnityObject LoadAsset(string path);
    }
}
