using DotEngine.NodeGraph.Flow;
using GraphProcessor;

namespace GameEditor.AssetSetting
{
    [Node("Start")]
    [NodeCapability(isDeletable =false)]
    [NodeMenuItem("Asset Setting/Start")]
    [NodeTag("asset-setting")]
    public class AssetSettingStartNode : BaseStartFlowNode
    {
    }
}
