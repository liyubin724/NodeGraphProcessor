using GraphProcessor;
using System;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Asset To Disk Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Path/Asset To Disk Path")]
    public class AssetToDiskPathNode : BaseNode
    {
        [Input]
        public string assetPath;

        [Output]
        public string diskPath;

        protected override void Process()
        {
            if (string.IsNullOrEmpty(assetPath))
            {
                AddMessage("The path of asset is empty", NodeMessageType.Error);
                return;
            }

            var path = AssetUtil.GetDiskPath(assetPath);
            if (string.IsNullOrEmpty(path))
            {
                AddMessage($"The path({assetPath}) is not in Assets", NodeMessageType.Error);
                return;
            }

            diskPath = path;
        }
    }
}
