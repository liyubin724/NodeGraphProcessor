using GraphProcessor;
using UnityEngine;

namespace DotEditor.Graph.Assets
{
    [CreateAssetMenu(menuName = "Graphs/Asset Setting Graph", fileName = "asset-setting-graph")]
    [GraphIdentify("asset-setting-graph", new string[] { "common", "asset" })]
    public class AssetSettingGraph : GraphAsset
    {
    }
}
