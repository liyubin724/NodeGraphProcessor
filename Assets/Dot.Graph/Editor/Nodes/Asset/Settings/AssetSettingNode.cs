using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    public abstract class AssetSettingNode : BaseNode
    {
        [Input(allowMultiple = true)]
        public string[] assetPaths;

        [CustomPortInput(nameof(assetPaths), typeof(string[]), allowCast = true)]
        public void GetInputs(List<SerializableEdge> edges)
        {
            var allInputPaths = edges.Select(e => (string[])e.passThroughBuffer).ToArray();
            foreach (var inputPaths in allInputPaths)
            {
                foreach (var path in inputPaths)
                {
                    if (string.IsNullOrEmpty(path)) continue;
                    if (Array.IndexOf(assetPaths, path) >= 0) continue;

                    var tempPaths = assetPaths;
                    assetPaths = new string[tempPaths.Length + 1];
                    Array.Copy(tempPaths, assetPaths, tempPaths.Length);
                    assetPaths[assetPaths.Length - 1] = path;
                }
            }
        }

        protected override void BeforePullInputDatas()
        {
            assetPaths = new string[0];
        }

        protected override void Process()
        {
            if (assetPaths == null || assetPaths.Length == 0)
            {
                AddMessage($"The assetPaths is empty", NodeMessageType.Error);
                return;
            }

            foreach (var assetPath in assetPaths)
            {
                var importer = AssetImporter.GetAtPath(assetPath);
                OnSetImporter(assetPath, importer);

                AssetDatabase.ImportAsset(assetPath);
            }
        }

        protected abstract void OnSetImporter(string assetPath, AssetImporter importer);
    }
}
