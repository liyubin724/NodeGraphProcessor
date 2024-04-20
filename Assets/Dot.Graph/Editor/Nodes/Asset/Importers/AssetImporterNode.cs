using GraphProcessor;
using System;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    //    [Serializable]
    //    [NodeIdentity("Asset Importer(Editor)", new string[] { "editor", "importer", "asset" })]
    //    [NodeMenuItem("Assets/Filters/Importer(In Editor)")]
    public abstract class AssetImporterNode<T> : BaseNode where T : AssetImporter
    {
        [Input]
        public string assetPath;

        [Output]
        public T importer;

        protected override void Process()
        {
            importer = null;
            if (string.IsNullOrEmpty(assetPath))
            {
                AddMessage($"The path({assetPath}) is empty", NodeMessageType.Error);
                return;
            }

            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            if (asset == null)
            {
                AddMessage($"The path({assetPath}) is not a asset of Unity", NodeMessageType.Error);
                return;
            }

            importer = AssetImporter.GetAtPath(assetPath) as T;
        }
    }
}
