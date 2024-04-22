using GraphProcessor;
using System;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Texture Platform Setting(Editor)", new string[] { "editor", "setting", "asset" })]
    [NodeMenuItem("Assets/Setting/Texture Platform Setting(In Editor)")]
    public class TexturePlatformSettingNode : BaseNode
    {
        [Output]
        public TextureImporterPlatformSettings output;

        public TexturePlatformSetting setting = new TexturePlatformSetting();

        protected override void Process()
        {
            output = new TextureImporterPlatformSettings();
            output.overridden = true;
            output.name = setting.name;
            output.maxTextureSize = setting.maxSize;
            output.resizeAlgorithm = setting.resizeAlgorithm;
            output.format = (TextureImporterFormat)setting.format;
        }
    }
}
