using GraphProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameEditor.Asset.ImportSetting
{
    [Serializable]
    [Node("File Ext Filter")]
    [NodeMenuItem("Asset Importer/Filter/File Ext Filter")]
    [NodeTag("asset-importer")]
    public class AssetFileExtFilterNode : BaseAssetFilterNode
    {
        public List<string> extensions;

        protected override bool IsValid(string assetPath)
        {
            if(extensions == null || extensions.Count == 0)
            {
                return false;
            }

            string ext = Path.GetExtension(assetPath).ToLower();
            if(string.IsNullOrEmpty(ext))
            {
                return false;
            }

            return extensions.Any((e) =>
            {
                if (string.IsNullOrEmpty(e))
                {
                    return false;
                }

                return e.ToLower() == ext;
            });
        }
    }
}
