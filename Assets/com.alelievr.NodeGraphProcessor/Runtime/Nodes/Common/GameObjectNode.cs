﻿using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Game Object")]
    [NodeIdentity("Game Object")]
    public class GameObjectNode : BaseNode, ICreateNodeFrom<GameObject>
    {
        [Output(name = "Out"), SerializeField]
        public GameObject output;

        public bool InitializeNodeFromObject(GameObject value)
        {
            output = value;
            return true;
        }
    }
}
