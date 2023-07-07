using GraphProcessor;
using System.Collections.Generic;

namespace GameEditor.Asset.ImportSetting
{
    public abstract class BaseAssetFilterNode : BaseAssetImportNode
    {
        [Input("Assets")]
        public List<string> inputAssetPaths;

        [Output("Assets")]
        public List<string> outputAssetPaths;

        protected override void Process()
        {
            outputAssetPaths = new List<string>();

            if(inputAssetPaths == null || inputAssetPaths.Count == 0)
            {
                return;
            }

            foreach(string assetPath in inputAssetPaths)
            {
                if(string.IsNullOrEmpty(assetPath)) continue;

                if(IsValid(assetPath))
                {
                    outputAssetPaths.Add(assetPath);
                }
            }
        }

        protected abstract bool IsValid(string assetPath);
    }
}
