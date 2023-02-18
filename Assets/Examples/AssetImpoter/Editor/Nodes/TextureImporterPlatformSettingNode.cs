using GraphProcessor;
using UnityEditor;

public enum ETargetPlatform
{
    Standalone = 0,
    Android,
    iPhone,
}

[System.Serializable, NodeMenuItem("Asset Importer/Texture Platform Setting")]
[NodeIdentity("TexturePlatformSetting", new string[] { "AssetImpoter" })]
public class TextureImporterPlatformSettingNode : BaseNode
{
    [Output("setting")]
    public TextureImporterPlatformSettings winSetting;

    public ETargetPlatform platform = ETargetPlatform.Standalone;
    public int maxSize;
    public TextureImporterFormat format = TextureImporterFormat.RGBA32;

    protected override void Process()
    {
        winSetting = new TextureImporterPlatformSettings();
        winSetting.maxTextureSize = maxSize;
    }
}
