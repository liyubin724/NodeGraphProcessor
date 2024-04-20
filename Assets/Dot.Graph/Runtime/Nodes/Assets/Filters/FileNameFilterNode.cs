using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("File Name Filter", new string[] { "filter", "asset" })]
    [NodeMenuItem("Assets/Filters/File Name")]
    public class FileNameFilterNode : FilterNode
    {
        public bool withExt = false;
        public string regex;

        protected override void Process()
        {
            if (inputAssets == null || inputAssets.Length == 0) return;

            List<string> results = new List<string>();

            foreach (var item in inputAssets)
            {
                if (item == null) continue;
                if (string.IsNullOrEmpty(item)) continue;

                string fileName = withExt ? Path.GetFileName(item) : Path.GetFileNameWithoutExtension(item);
                if (string.IsNullOrEmpty(fileName)) continue;

                if (string.IsNullOrEmpty(regex) || Regex.IsMatch(fileName, regex))
                {
                    results.Add(item);
                }
            }

            outputAssets = results.ToArray();
        }
    }
}
