using GraphProcessor;
using System;
using UnityEngine.U2D;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Sprite Atlas")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Unity Object/Sprite Atlas")]
    public class SpriteAtlasValueNode : BaseUObjectValueNode<SpriteAtlas>
    {
    }
}
