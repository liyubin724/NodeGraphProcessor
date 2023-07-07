using GraphProcessor;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GameEditor.Asset.ImportSetting
{
    public enum AssetFileNameFormatType
    {
        Equal = 0,
        StartsWith,
        EndsWith,
        Contains,
        Regex,
    }

    [Serializable]
    [Node("File Name Filter")]
    [NodeMenuItem("Asset Importer/Filter/File Name Filter")]
    [NodeTag("asset-importer")]
    public class AssetFileNameFilterNode : BaseAssetFilterNode
    {
        public string expression;

        public bool isIncludeExt = true;
        public AssetFileNameFormatType format = AssetFileNameFormatType.Regex;

        protected override bool IsValid(string assetPath)
        {
            if (string.IsNullOrEmpty(expression)) return false;

            string fileName = isIncludeExt ? Path.GetFileName(assetPath) : Path.GetFileNameWithoutExtension(assetPath);
            if (format == AssetFileNameFormatType.Equal)
            {
                return fileName == expression;
            }
            else if (format == AssetFileNameFormatType.StartsWith)
            {
                return fileName.StartsWith(expression);
            }
            else if (format == AssetFileNameFormatType.EndsWith)
            {
                return fileName.EndsWith(expression);
            }
            else if (format == AssetFileNameFormatType.Contains)
            {
                return fileName.Contains(expression);
            }
            else if (format == AssetFileNameFormatType.Regex)
            {
                return Regex.IsMatch(fileName, expression);
            }
            return false;
        }
    }
}
