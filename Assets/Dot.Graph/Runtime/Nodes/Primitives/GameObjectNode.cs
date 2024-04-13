using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("GameObject", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/GameObject")]
    public class GameObjectNode : PrimitiveNode<GameObject>, ICreateNodeFrom<GameObject>
    {
        public bool InitializeNodeFromObject(GameObject value)
        {
            this.value = value;
            return true;
        }
    }
}
