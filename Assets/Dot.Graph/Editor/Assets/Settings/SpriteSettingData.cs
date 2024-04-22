using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    public class SpriteSettingData
    {
        public int pixelsPerUnit = 100;
        public SpriteMeshType meshType = SpriteMeshType.FullRect;

        public bool sRGBTexture = true;
        public TextureImporterAlphaSource alphaSource = TextureImporterAlphaSource.FromInput;
        public bool alphaIsTransparency = true;

        public WrapMode wrapMode = WrapMode.Clamp;
        public FilterMode filterMode = FilterMode.Bilinear;
    }
}
