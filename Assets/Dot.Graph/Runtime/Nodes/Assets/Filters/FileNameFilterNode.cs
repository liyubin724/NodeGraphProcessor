using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("File Name Filter", new string[] { "filter", "asset" })]
    [NodeMenuItem("Assets/Filters/File Name Filter")]
    public class FileNameFilterNode : FilterNode
    {
        public string regex;

        protected override void Process()
        {
            if (input == null || input.Length == 0) return;

            List<string> results = new List<string>();

            foreach (var item in input)
            {
                if (item == null) continue;
                if (string.IsNullOrEmpty(item)) continue;

                string fileName = Path.GetFileNameWithoutExtension(item);
                if (string.IsNullOrEmpty(fileName)) continue;

                if (string.IsNullOrEmpty(regex) || Regex.IsMatch(fileName, regex))
                {
                    results.Add(item);
                }
            }

            output = results.ToArray();
        }
    }
}
