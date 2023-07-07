using GraphProcessor;
using System.Collections.Generic;

namespace GameEditor.Asset.ImportSetting
{
    public abstract class BaseAssetFinderNode : BaseAssetImportNode
    {
        [Output("Assets")]
        public List<string> assetPaths;
    }
}
