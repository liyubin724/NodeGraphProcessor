using GraphProcessor;
using System;
using UnityEditor;
using UnityEngine;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Sprite Setting(Editor)", new string[] { "editor", "setting", "asset" })]
    [NodeMenuItem("Assets/Setting/Sprite Setting(In Editor)")]
    public class SpriteSettingNode : AssetSettingNode
    {
        [HideInInspector]
        public SpriteImportMode mode = SpriteImportMode.Single;
        public int pixelsPerUnit = 100;
        public string packingTag = "";
        public SpriteMeshType meshType = SpriteMeshType.FullRect;

        [Space]
        public bool sRGBTexture = true;
        public TextureImporterAlphaSource alphaSource = TextureImporterAlphaSource.FromInput;
        public bool alphaIsTransparency = true;
        public bool readable = false;
        public bool mipmap = false;

        [Space]
        public TextureWrapMode wrapMode = TextureWrapMode.Clamp;
        public FilterMode filterMode = FilterMode.Bilinear;

        [Input]
        public TextureImporterPlatformSettings defaultSetting;
        [Input]
        public TextureImporterPlatformSettings standaloneSetting;
        [Input]
        public TextureImporterPlatformSettings androidSetting;
        [Input]
        public TextureImporterPlatformSettings iosSetting;


        protected override void OnSetImporter(string assetPath, AssetImporter importer)
        {
            TextureImporter textureImporter = importer as TextureImporter;

            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = mode;
            textureImporter.spritePackingTag = packingTag;
            textureImporter.alphaSource = alphaSource;
            textureImporter.alphaIsTransparency = alphaIsTransparency;
            textureImporter.sRGBTexture = sRGBTexture;
            textureImporter.isReadable = readable;
            textureImporter.mipmapEnabled = mipmap;

            textureImporter.wrapMode = wrapMode;
            textureImporter.filterMode = filterMode;

            TextureImporterSettings tis = new TextureImporterSettings();
            textureImporter.ReadTextureSettings(tis);
            {
                tis.spriteMeshType = meshType;
                tis.spritePixelsPerUnit = pixelsPerUnit;
            }
            textureImporter.SetTextureSettings(tis);

            textureImporter.SetPlatformTextureSettings(defaultSetting);
            textureImporter.SetPlatformTextureSettings(standaloneSetting);
            textureImporter.SetPlatformTextureSettings(androidSetting);
            textureImporter.SetPlatformTextureSettings(iosSetting);
        }
    }
}
