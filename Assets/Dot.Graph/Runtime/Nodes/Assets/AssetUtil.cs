using UnityEngine;

namespace DotEngine.Graph
{
    public static class AssetUtil
    {
        private static string AssetPath = Application.dataPath.Replace("\\", "/");
        public static string GetAssetDiskPath()
        {
            return AssetPath;
        }

        public static string GetAssetPath(string filePath)
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

        public static string GetDiskPath(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath))
            {
                return null;
            }

            return $"{AssetPath}{assetPath.Substring("Assets".Length)}";
        }
    }
}
