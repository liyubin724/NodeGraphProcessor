using GraphProcessor;
using System;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Disk To Asset Path", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Path/Disk To Asset Path")]
    public class DiskToAssetPathNode : BaseNode
    {
        [Input]
        public string diskPath;

        [Output]
        public string assetPath;

        protected override void Process()
        {
            assetPath = null;

            if (string.IsNullOrEmpty(diskPath))
            {
                AddMessage("The path of asset is empty", NodeMessageType.Error);
                return;
            }

            var path = AssetUtil.GetAssetPath(diskPath);
            if (string.IsNullOrEmpty(path))
            {
                AddMessage($"The path({diskPath}) is not in Assets", NodeMessageType.Error);
                return;
            }

            assetPath = path;
        }
    }
}
