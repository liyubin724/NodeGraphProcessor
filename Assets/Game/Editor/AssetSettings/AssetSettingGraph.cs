using GraphProcessor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotEditor.AssetSettings
{
    [CreateAssetMenu(fileName = "asset-setting-graph.asset", menuName = "Create/Asset Setting Graph")]
    [GraphIdentify("Asset Setting Graph", new string[] { "common", "debug", "assets" })]
    public class AssetSettingGraph : BaseGraph
    {

    }
}

