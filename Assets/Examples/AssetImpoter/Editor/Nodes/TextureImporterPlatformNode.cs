using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Asset Importer/Texture Importer Platform")]
[NodeIdentity("TextureImporterPlatform", new string[] { "AssetImpoter" })]
public class TextureImporterPlatformNode : BaseNode
{
    [Input("assert paths")]
    public List<string> assertPaths = new List<string>();

    [Input("standalone setting"),Tooltip("PlatformSettings for standalone")]
    public TextureImporterPlatformSettings standaloneSetting;
    [Input("android setting"), Tooltip("PlatformSettings for android")]
    public TextureImporterPlatformSettings androidSetting;
    [Input("iPhone setting"), Tooltip("PlatformSettings for iPhone")]
    public TextureImporterPlatformSettings iPhoneSetting;

    protected override void Process()
    {
        
    }
}
