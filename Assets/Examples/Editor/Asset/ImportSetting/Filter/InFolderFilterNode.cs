using GraphProcessor;
using System;
using System.IO;

namespace GameEditor.Asset.ImportSetting
{
    public enum FolderType
    {
        Parent = 0,
        AnyOfParent,
        StartsWith,
        EndsWith,
        Contains,
    }


    [Serializable]
    [Node("In Folder Filter")]
    [NodeMenuItem("Asset Importer/Filter/In Folder Filter")]
    [NodeTag("asset-importer")]
    public class InFolderFilterNode : BaseFilterNode
    {
        public string folderName;
        public FolderType folderType = FolderType.Parent;

        protected override bool IsValid(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath)) return false;

            string folderPath = Path.GetDirectoryName(assetPath).Replace("\\","/");
            if (folderType == FolderType.AnyOfParent || folderType == FolderType.Parent)
            {
                string[] parentFolders = folderPath.Split('/');
                if (parentFolders.Length == 0)
                {
                    return false;
                }
                if (folderType == FolderType.AnyOfParent)
                {
                    return Array.IndexOf(parentFolders, folderName) >= 0;
                }
                else
                {
                    return parentFolders[parentFolders.Length - 1] == folderName;
                }
            }
            else if (folderType == FolderType.StartsWith)
            {
                return folderPath.StartsWith(folderName);
            }
            else if (folderType == FolderType.EndsWith)
            {
                return folderPath.EndsWith(folderName);
            }
            else if (folderType == FolderType.Contains)
            {
                return folderPath.Contains(folderName);
            }

            return false;
        }
    }
}
