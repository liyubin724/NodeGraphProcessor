using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Scriptable Object", new string[] { "uobject", "common" })]
    [NodeMenuItem("Common/UObjects/Scriptable Object")]
    public class ScriptableObjectAssetNode : UObjectNode<ScriptableObject>
    {
    }
}
