using GraphProcessor;
using System;
using UnityEditor;
using UnityEngine;

namespace GameEditor.Asset.ImportSetting
{
    [Serializable]
    [Node("Sprite Importer")]
    [NodeMenuItem("Asset Importer/Importer/Sprite Importer")]
    [NodeTag("asset-importer")]
    public class SpriteImporterSettingNode : BaseTextureImporterSettingNode
    {
        public SpriteImportMode importMode = SpriteImportMode.Single;
        public int perUnit = 100;
        public SpriteMeshType meshType = SpriteMeshType.Tight;
        public uint extrudeEdges = 1;
        public PivotMode pivotMode = PivotMode.Center;
        public bool enablePhysics = true;

        protected override void SetImporter(string assetPath, TextureImporter importer)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.textureShape = TextureImporterShape.Texture2D;

            base.SetImporter(assetPath, importer);

            importer.spriteImportMode = importMode;
            importer.spritePixelsPerUnit= perUnit;

            TextureImporterSettings tis = new TextureImporterSettings();
            importer.ReadTextureSettings(tis);
            tis.spriteMeshType = meshType;
            tis.spriteExtrude = extrudeEdges;
            tis.spriteAlignment = (int)pivotMode;
            tis.spriteGenerateFallbackPhysicsShape = enablePhysics;
            importer.SetTextureSettings(tis);
        }
    }
}
