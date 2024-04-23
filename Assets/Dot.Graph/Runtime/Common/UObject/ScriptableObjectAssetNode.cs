using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Texture 2D", new string[] { "uobject", "common" })]
    [NodeMenuItem("Common/UObjects/Texture 2D")]
    public class ScriptableObjectAssetNode : UObjectNode<ScriptableObject>
    {
    }
}
