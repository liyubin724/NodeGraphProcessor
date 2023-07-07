using UnityEditor;
using UnityEngine;

namespace GameEditor.Asset.ImportSetting
{
    public abstract class BaseTextureImporterSettingNode : BasetImporterSettingNode<TextureImporter>
    {
        public bool isRGB = true;
        public TextureImporterAlphaSource alphaSource = TextureImporterAlphaSource.FromInput;
        public bool alphaIsTransparent = true;
        public bool isWritable = false;
        public bool isMipmap = false;

        public TextureWrapMode wrapMode = TextureWrapMode.Clamp;
        public FilterMode filterMode = FilterMode.Bilinear;
        public int anisoLevel = 1;

        protected override void SetImporter(string assetPath, TextureImporter importer)
        {
            importer.sRGBTexture = isRGB;
            importer.alphaSource= alphaSource;
            importer.alphaIsTransparency= alphaIsTransparent;
            importer.isReadable = isWritable;
            importer.mipmapEnabled= isMipmap;

            importer.wrapMode = wrapMode;
            importer.filterMode= filterMode;
        }
    }
}
