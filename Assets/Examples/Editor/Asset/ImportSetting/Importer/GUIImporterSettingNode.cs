using GraphProcessor;
using System;
using UnityEditor;

namespace GameEditor.Asset.ImportSetting
{
    [Serializable]
    [Node("GUI Importer")]
    [NodeMenuItem("Asset Importer/Importer/GUI Importer")]
    [NodeTag("asset-importer")]
    public class GUIImporterSettingNode : BaseTextureImporterSettingNode
    {
        protected override void SetImporter(string assetPath, TextureImporter importer)
        {
            importer.textureType = TextureImporterType.GUI;
            importer.textureShape = TextureImporterShape.Texture2D;

            base.SetImporter(assetPath, importer);

            importer.npotScale = TextureImporterNPOTScale.None;
            importer.mipmapEnabled = false;
            importer.alphaSource = TextureImporterAlphaSource.FromInput;
            importer.alphaIsTransparency = true;
            importer.isReadable = false;
            importer.anisoLevel = 1;
        }
    }
}
