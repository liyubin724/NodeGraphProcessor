using System;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    public class TexturePlatformSettingData
    {
        public int maxSize = 2048;
        public TextureResizeAlgorithm resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
        public int format = 4;
    }

    [Serializable]
    public class DefaultTexturePlatformSettingData : TexturePlatformSettingData { }
    [Serializable]
    public class StandaloneTexturePlatformSettingData : TexturePlatformSettingData { }
    [Serializable]
    public class AndroidTexturePlatformSettingData : TexturePlatformSettingData { }
    [Serializable]
    public class IOSTexturePlatformSettingData : TexturePlatformSettingData { }
}
