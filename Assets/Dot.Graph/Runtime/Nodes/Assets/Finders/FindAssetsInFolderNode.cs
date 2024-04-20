using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Find Assets", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Finder/Find Assets From Folder")]
    public class FindAssetsInFolderNode : BaseNode
    {
        [Input]
        public string folderPath;

        [Output]
        public string[] assets;

        public bool includeSubdir = true;
        public bool ignoreMeta = true;

        protected override void Process()
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                AddMessage("The path of folder is empty", NodeMessageType.Error);
                return;
            }

            var diskPath = AssetUtil.GetDiskPath(folderPath);
            if (string.IsNullOrEmpty(diskPath))
            {
                AddMessage("The folder in not in Assets", NodeMessageType.Error);
                return;
            }

            if (!Directory.Exists(diskPath))
            {
                AddMessage($"The folder({folderPath}) is not found", NodeMessageType.Error);
                return;
            }

            List<string> paths = new List<string>();

            var files = Directory.GetFiles(diskPath, "*", includeSubdir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var assetPath = AssetUtil.GetAssetPath(file);
                var ext = Path.GetExtension(assetPath).ToLower();
                if (ext == ".meta")
                {
                    continue;
                }

                paths.Add(assetPath);
            }

            assets = paths.ToArray();
        }
    }
}
