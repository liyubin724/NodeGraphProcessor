using GraphProcessor;
using System;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    [NodeIdentity("SpriteAtlas Setting(Editor)", new string[] { "editor", "setting", "asset" })]
    [NodeMenuItem("Assets/Setting/SpriteAtlas Setting(In Editor)")]
    public class SpriteAtlasSettingNode : AssetSettingNode
    {
        public bool isIncludeInBuild = true;

        public bool isAllowRotation = false;
        public bool isTightPacking = true;
        public bool isAlphaDilation = false;
        public int padding = 4;

        public bool readable = false;
        public bool mipmap = false;
        public bool sRGBTexture = true;

        [Space]
        public FilterMode filterMode = FilterMode.Bilinear;

        [Input]
        public TextureImporterPlatformSettings defaultSetting;
        [Input]
        public TextureImporterPlatformSettings standaloneSetting;
        [Input]
        public TextureImporterPlatformSettings androidSetting;
        [Input]
        public TextureImporterPlatformSettings iosSetting;


        protected override void OnSetImporter(string assetPath, AssetImporter _)
        {
            var atlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(assetPath);
            atlas.SetIsVariant(false);
            atlas.SetIncludeInBuild(isIncludeInBuild);


            var packingSettings = atlas.GetPackingSettings();
            packingSettings.enableRotation = isAllowRotation;
            packingSettings.enableTightPacking = isTightPacking;
            packingSettings.enableAlphaDilation = isAlphaDilation;
            packingSettings.padding = padding;
            atlas.SetPackingSettings(packingSettings);

            var textureSetting = atlas.GetTextureSettings();
            textureSetting.readable = readable;
            textureSetting.generateMipMaps = mipmap;
            textureSetting.sRGB = sRGBTexture;
            textureSetting.filterMode = filterMode;
            atlas.SetTextureSettings(textureSetting);

            atlas.SetPlatformSettings(defaultSetting);
            atlas.SetPlatformSettings(standaloneSetting);
            atlas.SetPlatformSettings(androidSetting);
            atlas.SetPlatformSettings(iosSetting);
        }
    }
}
