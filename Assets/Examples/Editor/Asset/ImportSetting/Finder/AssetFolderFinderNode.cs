using DotEditor.Core.Utilities;
using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameEditor.Asset.ImportSetting
{
    [Serializable]
    [Node("Folder Finder")]
    [NodeMenuItem("Asset Importer/Finder/Folder Finder")]
    [NodeTag("asset-importer")]
    public class AssetFolderFinderNode : BaseAssetFinderNode
    {
        [Input]
        public List<string> assetFolders;

        protected override void Process()
        {
            ClearMessages();

            if (assetFolders == null || assetFolders.Count == 0)
            {
                return;
            }

            assetPaths = new List<string>();

            foreach (var assetFolder in assetFolders)
            {
                if (string.IsNullOrEmpty(assetFolder))
                {
                    AddMessage("The folder is null", NodeMessageType.Error);
                    continue;
                }
                if (!assetFolder.StartsWith("Assets"))
                {
                    AddMessage($"The folder(${assetFolder}) is not start with Assets", NodeMessageType.Error);
                    continue;
                }
                string diskPath = PathUtility.GetDiskPath(assetFolder);
                if (!Directory.Exists(diskPath))
                {
                    AddMessage($"The folder(${assetFolder}) is not found", NodeMessageType.Error);
                    continue;
                }

                string[] assets = AssetDatabaseUtility.GetAssets(assetFolder, true);
                assetPaths.AddRange(assets);
            }

            assetPaths = assetPaths.Distinct().ToList();
        }

        [CustomPortBehavior(nameof(assetFolders))]
        public IEnumerable<PortData> ListAssetFolder(List<SerializableEdge> edges)
        {
            for (int i = 0; i < edges.Count + 1; i++)
            {
                yield return new PortData
                {
                    displayName = "Folder " + i,
                    displayType = typeof(string),
                    identifier = i.ToString(),
                };
            }
        }

        [CustomPortInput(nameof(assetFolders), typeof(string), allowCast = true)]
        public void GetFolders(List<SerializableEdge> edges) 
        {
            assetFolders.AddRange(edges.Select(e => (string)e.passThroughBuffer));

            assetFolders = assetFolders.Distinct().ToList();
        }
    }
}
