using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace GameEditor.Asset.ImportSetting
{
    public enum TextureMaxSizeType
    {
        S32 = 32,
        S64 = 64,
        S128 = 128,
        S256 = 256,
        S512 = 512,
        S1024 = 1024,
        S2048 = 2048,
        S4096 = 4096,
    }

    public abstract class BaseTexturePlatformSettingNode : BaseAssetSettingNode
    {
        [Input("Assets")]
        public List<string> inputAssetPaths;

        public TextureMaxSizeType maxSizeType = TextureMaxSizeType.S1024;

        //protected override void Process()
        //{
        //    if (inputAssetPaths != null && inputAssetPaths.Count == 0)
        //    {
        //        return;
        //    }

        //    foreach (var assetPath in inputAssetPaths)
        //    {
        //        if (string.IsNullOrEmpty(assetPath)) continue;

        //        var importer = AssetImporter.GetAtPath(assetPath) as TImporter;
        //        if (importer != null)
        //        {
        //            SetImporter(assetPath, importer);
        //        }

        //        AssetDatabase.ImportAsset(assetPath);
        //    }
        //}

        protected abstract void SetWinPlatform(string assetPath, TextureImporterPlatformSettings tips);
        protected abstract void SetAndroidPlatform(string assetPath, TextureImporterPlatformSettings tips);
        protected abstract void SetIOSPlatform(string assetPath, TextureImporterPlatformSettings tips);
    }
}
