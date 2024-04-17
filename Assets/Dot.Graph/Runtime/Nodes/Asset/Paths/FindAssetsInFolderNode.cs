using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Find Assets In Folder", new string[] { "path", "assets" })]
    [NodeMenuItem("Assets/Paths/Find Assets In Folder")]
    public class FindAssetsInFolderNode : BaseNode
    {
        [Input]
        [ShowAsDrawer]
        public string folderPath;

        [Output]
        public List<string> assetPaths = new List<string>();

        public bool includeSubdir = true;

        protected override void Process()
        {
            assetPaths.Clear();

            if (string.IsNullOrEmpty(folderPath))
            {
                AddMessage("The folder is empty", NodeMessageType.Error);
                return;
            }

            var diskPath = AssetUtil.GetDiskFilePath(folderPath);
            if (string.IsNullOrEmpty(diskPath))
            {
                AddMessage("The folder in not in Assets", NodeMessageType.Error);
            }
            if (!Directory.Exists(diskPath))
            {
                AddMessage($"The folder({folderPath}) is not found", NodeMessageType.Error);
                return;
            }

            var files = Directory.GetFiles(diskPath, "*", includeSubdir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var assetPath = AssetUtil.GetAssetFilePath(file);
                var ext = Path.GetExtension(assetPath).ToLower();
                if (ext == ".meta")
                {
                    continue;
                }

                assetPaths.Add(assetPath);
            }
        }
    }
}
