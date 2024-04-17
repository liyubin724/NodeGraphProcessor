using GraphProcessor;
using UnityEngine;

namespace DotEngine.Graph
{
    public abstract class AssetPathNode : BaseNode
    {
        [Output]
        [SerializeField]
        public string assetPath;
    }
}
