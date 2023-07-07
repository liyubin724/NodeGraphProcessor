using GraphProcessor;
using System.Collections.Generic;
using UnityEditor;

namespace GameEditor.Asset.ImportSetting
{
    public abstract class BasetImporterSettingNode<TImporter> : BaseAssetSettingNode where TImporter : AssetImporter
    {
        [Input("Assets")]
        public List<string> inputAssetPaths;

        protected override void Process()
        {
            if(inputAssetPaths != null && inputAssetPaths.Count == 0)
            {
                return;
            }

            foreach(var assetPath in inputAssetPaths)
            {
                if(string.IsNullOrEmpty(assetPath)) continue;

                var importer = AssetImporter.GetAtPath(assetPath) as TImporter;
                if(importer != null)
                {
                    SetImporter(assetPath, importer);
                }
            }
        }

        protected abstract void SetImporter(string assetPath, TImporter importer);
    }
}
