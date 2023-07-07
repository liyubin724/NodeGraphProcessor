using GraphProcessor;
using System;
using UnityEditor;

namespace GameEditor.Asset.ImportSetting
{
    [Serializable]
    [Node("Texture2D Importer")]
    [NodeMenuItem("Asset Importer/Importer/Texture2D Importer")]
    [NodeTag("asset-importer")]
    public class Texture2DImporterSettingNode : BaseTextureImporterSettingNode
    {
        protected override void SetImporter(string assetPath, TextureImporter importer)
        {
            importer.textureType = TextureImporterType.Default;
            importer.textureShape = TextureImporterShape.Texture2D;

            base.SetImporter(assetPath, importer);
        }
    }
}
