using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Game Object", new string[] { "uobject", "common" })]
    [NodeMenuItem("Common/UObjects/Game Object")]
    public class GameObjectNode : UObjectNode<GameObject>
    {
    }
}
