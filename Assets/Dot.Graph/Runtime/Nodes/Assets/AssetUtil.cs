using UnityEngine;

namespace DotEngine.Graph
{
    public static class AssetUtil
    {
        private static string AssetPath = Application.dataPath.Replace("\\", "/");
        public static string GetAssetPath()
        {
            return AssetPath;
        }

        public static string GetAssetFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            filePath = filePath.Replace("\\", "/");
            if (filePath.StartsWith(AssetPath))
            {
                filePath = filePath.Substring(AssetPath.Length - "Assets".Length);
                return filePath;
            }

            return null;
        }

        public static string GetDiskFilePath(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath))
            {
                return null;
            }

            return $"{AssetPath}{assetPath.Substring("Assets".Length)}";
        }
    }
}
