﻿using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Texture As Sprite(Editor)", new string[] { "editor", "setting", "asset" })]
    [NodeMenuItem("Assets/Setting/Texture As Sprite(In Editor)")]
    public class TextureAsSpriteNode : BaseNode
    {
        [Input(allowMultiple = true)]
        public string[] assetPaths;

        public int pixelsPerUnit = 100;
        public SpriteMeshType meshType = SpriteMeshType.FullRect;


        public bool sRGBTexture = true;
        public TextureImporterAlphaSource alphaSource = TextureImporterAlphaSource.FromInput;
        public bool alphaIsTransparency = true;

        public SpriteSettingData setting = new SpriteSettingData();

        [Input]
        public TextureImporterPlatformSettings defaultSetting;
        [Input]
        public TextureImporterPlatformSettings standaloneSetting;
        [Input]
        public TextureImporterPlatformSettings androidSetting;
        [Input]
        public TextureImporterPlatformSettings iosSetting;

        [CustomPortInput(nameof(assetPaths), typeof(string[]), allowCast = true)]
        public void GetInputs(List<SerializableEdge> edges)
        {
            var allInputPaths = edges.Select(e => (string[])e.passThroughBuffer).ToArray();
            foreach (var inputPaths in allInputPaths)
            {
                foreach (var path in inputPaths)
                {
                    if (string.IsNullOrEmpty(path)) continue;
                    if (Array.IndexOf(assetPaths, path) >= 0) continue;

                    var tempPaths = assetPaths;
                    assetPaths = new string[tempPaths.Length + 1];
                    Array.Copy(tempPaths, assetPaths, tempPaths.Length);
                    assetPaths[assetPaths.Length - 1] = path;
                }
            }
        }

        protected override void BeforePullInputDatas()
        {
            assetPaths = new string[0];
        }

        protected override void Process()
        {
            if (assetPaths == null || assetPaths.Length == 0)
            {
                AddMessage($"The assetPaths is empty", NodeMessageType.Error);
                return;
            }

            foreach (var assetPath in assetPaths)
            {
                SetAssetAsSprite(assetPath);
            }
        }

        private void SetAssetAsSprite(string assetPath)
        {
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
            importer.spritePackingTag = "";
            importer.alphaSource = alphaSource;
            importer.alphaIsTransparency = alphaIsTransparency;
            importer.sRGBTexture = sRGBTexture;
            importer.isReadable = false;
            importer.mipmapEnabled = false;

            importer.wrapMode = TextureWrapMode.Clamp;
            importer.filterMode = FilterMode.Bilinear;

            TextureImporterSettings tis = new TextureImporterSettings();
            importer.ReadTextureSettings(tis);

            tis.spriteMeshType = meshType;
            tis.spritePixelsPerUnit = pixelsPerUnit;

            importer.SetTextureSettings(tis);

            importer.SetPlatformTextureSettings(defaultSetting);
            importer.SetPlatformTextureSettings(standaloneSetting);
            importer.SetPlatformTextureSettings(androidSetting);
            importer.SetPlatformTextureSettings(iosSetting);

            AssetDatabase.ImportAsset(assetPath);
        }
    }
}
