using DotEditor.Core.Utilities;
using DotEngine.NodeGraph.Flow;
using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace GameEditor.AssetSetting
{
    [Serializable]
    [Node("Target Folder")]
    [NodeMenuItem("Asset Setting/Origin/Target Folder")]
    [NodeTag("asset-setting")]
    public class AssetFolderNode : BaseLinearFlowNode
    {
        [Input]
        public List<string> assetFolders;

        [Output("Assets")]
        public List<string> assetPaths;

        protected override void Process()
        {
            ClearMessages();

            if(assetFolders == null || assetFolders.Count == 0)
            {
                return;
            }

            if (assetPaths == null) 
            { 
                assetPaths = new List<string>();
            }
            assetPaths.Clear();

            foreach(var assetFolder in  assetFolders)
            {
                if (string.IsNullOrEmpty(assetFolder))
                {
                    AddMessage("The folder is null", NodeMessageType.Error);
                    continue;
                }
                if (!assetFolder.StartsWith("Assets"))
                {
                    AddMessage($"The folder(${assetFolder}) is not start with Assets",NodeMessageType.Error);
                    continue;
                }
                string diskPath = PathUtility.GetDiskPath(assetFolder);
                if(!Directory.Exists(diskPath))
                {
                    AddMessage($"The folder(${assetFolder}) is not found",NodeMessageType.Error);
                    continue;
                }

                string[] assets = AssetDatabaseUtility.GetAssets(assetFolder,true);
                foreach(string assetPath in assets)
                {
                    var ext = Path.GetExtension(assetPath).ToLower();
                    if(string.IsNullOrEmpty(ext) || ext == ".meta")
                    {
                        continue;
                    }

                    assetPaths.Add(assetPath);
                }
            }

            assetPaths = assetPaths.Distinct().ToList();
        }

        [CustomPortBehavior(nameof(assetFolders))]
        IEnumerable<PortData> ListAssetFolder(List<SerializableEdge> edges)
        {
            for(int i =0;i< edges.Count + 1; i++)
            {
                yield return new PortData
                {
                    displayName = "Asset Folder " + i,
                    displayType = typeof(string),
                    identifier = i.ToString(),
                };
            }
        }
    }
}
