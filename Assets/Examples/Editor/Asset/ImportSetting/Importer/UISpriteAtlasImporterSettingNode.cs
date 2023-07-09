using GraphProcessor;
using System;
using UnityEditor;
using UnityEditor.U2D;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.U2D;

namespace GameEditor.Asset.ImportSetting
{
    public enum SpriteAtlasPaddingType
    {
        P2 = 2,
        P4 = 4,
        P8 = 8,
    }

    [Serializable]
    [Node("UI SpriteAtlas Importer")]
    [NodeMenuItem("Asset Importer/Importer/UI SpriteAtlas Importer")]
    [NodeTag("asset-importer")]
    public class UISpriteAtlasImporterSettingNode : BasetImporterSettingNode<SpriteAtlasImporter>
    {
        public bool isIncludeInBuild = true;
        
        public SpriteAtlasPaddingType paddingType = SpriteAtlasPaddingType.P2;
        public bool isRotation = false;
        public bool isTightPacking = false;
        public bool isAlphaDilation = false;

        public bool isRGB = true;
        public FilterMode filterMode = FilterMode.Bilinear;

        protected override void SetImporter(string assetPath, SpriteAtlasImporter importer)
        {
            SpriteAtlas atlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(assetPath);
            atlas.SetIsVariant(false);

            var loadedObjects = InternalEditorUtility.LoadSerializedFileAndForget(assetPath);
            if (loadedObjects.Length > 0)
            {
                var asset = loadedObjects[0] as SpriteAtlasAsset;
                if (asset != null)
                {
                    asset.SetIsVariant(false);
                }
            }

            var ps = importer.packingSettings;
            ps.padding = (int)paddingType;
            ps.enableRotation = isRotation;
            ps.enableTightPacking= isTightPacking;
            ps.enableAlphaDilation = isAlphaDilation;

            var ts = importer.textureSettings;
            ts.readable = false;
            ts.generateMipMaps= false;
            ts.sRGB = isRGB;
            ts.filterMode = filterMode;
        }
    }
}
