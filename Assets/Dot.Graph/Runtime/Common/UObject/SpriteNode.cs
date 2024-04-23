using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Sprite", new string[] { "uobject", "common" })]
    [NodeMenuItem("Common/UObjects/Sprite")]
    public class SpriteNode : UObjectNode<Sprite>
    {
    }
}
