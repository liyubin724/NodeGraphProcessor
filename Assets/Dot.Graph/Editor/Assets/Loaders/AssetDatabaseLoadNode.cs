using GraphProcessor;
using System;
using UnityEditor;
using UnityObject = UnityEngine.Object;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("AssetDatabase Load", new string[] { "editor", "asset" })]
    [NodeMenuItem("Assets/Loader/AssetDatabase Load")]
    public class AssetDatabaseLoadNode : AssetLoadNode
    {
        protected override UnityObject LoadAsset(string path)
        {
            return AssetDatabase.LoadAssetAtPath<UnityObject>(path);
        }

    }
}
