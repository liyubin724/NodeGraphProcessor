using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Unity Object/Game Object")]
    public class GameObjectValueNode : BaseUObjectValueNode<GameObject>
    {
    }
}
