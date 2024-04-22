using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("File Ext Filter", new string[] { "filter", "asset" })]
    [NodeMenuItem("Assets/Filters/File Ext")]
    public class FileExtFilterNode : FilterNode
    {
        public string ext;
        public bool ignoreCase = true;

        protected override void Process()
        {
            outputAssets = null;

            if (inputAssets == null || inputAssets.Length == 0) return;

            List<string> results = new List<string>();

            foreach (var assetPath in inputAssets)
            {
                if (assetPath == null) continue;
                if (string.IsNullOrEmpty(assetPath)) continue;

                string fileExt = Path.GetExtension(assetPath);
                if (string.IsNullOrEmpty(fileExt)) continue;

                if (string.IsNullOrEmpty(ext) || string.Compare(fileExt, ext, ignoreCase) == 0)
                {
                    results.Add(assetPath);
                }
            }

            outputAssets = results.ToArray();
        }
    }
}
