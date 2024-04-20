using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Find Assets", new string[] { "path", "asset" })]
    [NodeMenuItem("Assets/Finder/Find Assets From Folders")]
    public class FindAssetsInFoldersNode : BaseNode
    {
        [Input(allowMultiple = true)]
        public string[] folderPaths;

        [Output]
        public string[] assetPaths = new string[0];

        public bool includeSubdir = true;
        public bool ignoreMeta = true;

        [CustomPortBehavior(nameof(folderPaths))]
        IEnumerable<PortData> GetPortsForInputs(List<SerializableEdge> edges)
        {
            var maxIndex = -1;
            foreach (var edge in edges)
            {
                var identifier = edge.inputPortIdentifier;
                if (!string.IsNullOrEmpty(identifier) && int.TryParse(identifier, out var index))
                {
                    if (index > maxIndex)
                    {
                        maxIndex = index;
                    }
                }
            }
            for (int i = 0; i <= maxIndex + 1; i++)
            {
                yield return new PortData { displayName = i.ToString(), displayType = typeof(string), identifier = i.ToString() };
            }
        }

        [CustomPortInput(nameof(folderPaths), typeof(string), allowCast = true)]
        public void GetInputs(List<SerializableEdge> edges)
        {
            var paths = edges.Select(e => (string)e.passThroughBuffer).ToArray();
            foreach (var path in paths)
            {
                if (string.IsNullOrEmpty(path)) continue;
                if (Array.IndexOf(folderPaths, path) >= 0) continue;

                var tempPaths = folderPaths;
                folderPaths = new string[tempPaths.Length + 1];
                Array.Copy(tempPaths, folderPaths, tempPaths.Length);
                folderPaths[folderPaths.Length - 1] = path;
            }
        }

        protected override void BeforePullInputDatas()
        {
            folderPaths = new string[0];
        }

        protected override void Process()
        {
            assetPaths = null;

            List<string> assets = new List<string>();
            foreach (var folderPath in folderPaths)
            {
                var diskPath = AssetUtil.GetDiskPath(folderPath);
                if (string.IsNullOrEmpty(diskPath))
                {
                    AddMessage("The folder in not in Assets", NodeMessageType.Error);
                    continue;
                }

                if (!Directory.Exists(diskPath))
                {
                    AddMessage($"The folder({folderPath}) is not found", NodeMessageType.Error);
                    continue;
                }

                var files = Directory.GetFiles(diskPath, "*", includeSubdir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    var assetPath = AssetUtil.GetAssetPath(file);
                    var ext = Path.GetExtension(assetPath).ToLower();
                    if (ext == ".meta" && ignoreMeta)
                    {
                        continue;
                    }

                    assets.Add(assetPath);
                }
            }

            assetPaths = assets.Distinct().ToArray();
        }
    }
}
