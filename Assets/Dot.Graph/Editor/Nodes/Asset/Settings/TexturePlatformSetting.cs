using System;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    public class TexturePlatformSetting
    {
        public string name = "Default";
        public int maxSize = 2048;
        public TextureResizeAlgorithm resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        public int format = 4;
    }
}
