using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Resource Load", new string[] { "editor", "assets" })]
    [NodeMenuItem("Assets/Loader/Resource Load")]
    public class ResourceLoadNode : AssetLoadNode
    {
        protected override UnityEngine.Object LoadAsset(string path)
        {
            return Resources.Load(path);
        }
    }
}
