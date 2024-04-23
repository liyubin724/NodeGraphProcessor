using GraphProcessor;
using System;
using UnityEngine.U2D;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Sprite Atlas", new string[] { "uobject", "common" })]
    [NodeMenuItem("Common/UObjects/Sprite Atlas")]
    public class SpriteAtlasNode : UObjectNode<SpriteAtlas>
    {
    }
}
