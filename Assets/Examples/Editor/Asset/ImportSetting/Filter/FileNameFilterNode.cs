using GraphProcessor;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GameEditor.Asset.ImportSetting
{
    public enum FileNameFormatType
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
    public class FileNameFilterNode : BaseFilterNode
    {
        public string expression;

        public bool isIncludeExt = true;
        public FileNameFormatType format = FileNameFormatType.Regex;

        protected override bool IsValid(string assetPath)
        {
            if (string.IsNullOrEmpty(expression)) return false;

            string fileName = isIncludeExt ? Path.GetFileName(assetPath) : Path.GetFileNameWithoutExtension(assetPath);
            if (format == FileNameFormatType.Equal)
            {
                return fileName == expression;
            }
            else if (format == FileNameFormatType.StartsWith)
            {
                return fileName.StartsWith(expression);
            }
            else if (format == FileNameFormatType.EndsWith)
            {
                return fileName.EndsWith(expression);
            }
            else if (format == FileNameFormatType.Contains)
            {
                return fileName.Contains(expression);
            }
            else if (format == FileNameFormatType.Regex)
            {
                return Regex.IsMatch(fileName, expression);
            }
            return false;
        }
    }
}
