using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditor.Asset.ImportSetting
{
    [Serializable]
    [Node("In Folder Filter")]
    [NodeMenuItem("Asset Importer/Filter/In Folder Filter")]
    [NodeTag("asset-importer")]
    public class AssetInFolderFilterNode : BaseAssetFilterNode
    {
        protected override bool IsValid(string assetPath)
        {
            throw new NotImplementedException();
        }
    }
}
