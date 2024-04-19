using GraphProcessor;
using UnityEngine;

namespace DotEngine.Graph.Assets
{
    public abstract class AssetPathNode : BaseNode
    {
        [Output]
        [SerializeField]
        public string assetPath;
    }
}
