using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Text Asset", new string[] { "uobject", "common" })]
    [NodeMenuItem("Common/UObjects/Text Asset")]
    public class TextAssetNode : UObjectNode<TextAsset>
    {
    }
}
