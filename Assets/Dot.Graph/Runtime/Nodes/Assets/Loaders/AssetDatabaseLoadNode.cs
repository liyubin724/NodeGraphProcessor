using GraphProcessor;
using System;
using UnityObject = UnityEngine.Object;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("AssetDatabase Load", new string[] { "editor", "assets" })]
    [NodeMenuItem("Assets/Loader/AssetDatabase Load")]
    public class AssetDatabaseLoadNode : AssetLoadNode
    {
        protected override UnityObject LoadAsset(string path)
        {
#if UNITY_EDITOR
            return UnityEditor.AssetDatabase.LoadAssetAtPath<UnityObject>(path);
#endif
        }

    }
}
