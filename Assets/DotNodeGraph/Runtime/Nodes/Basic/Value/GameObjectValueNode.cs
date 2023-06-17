using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [NodeMenuItem("Basic/Values/Game Object")]
    public class GameObjectValueNode : BaseUObjectValueNode<GameObject>
    {
    }
}
