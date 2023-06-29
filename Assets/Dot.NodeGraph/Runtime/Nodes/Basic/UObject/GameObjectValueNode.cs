using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Game Object")]
    [NodeTag("basic")]
    [NodeMenuItem("Basic/Unity Object/Game Object")]
    public class GameObjectValueNode : BaseUObjectValueNode<GameObject>
    {
    }
}
