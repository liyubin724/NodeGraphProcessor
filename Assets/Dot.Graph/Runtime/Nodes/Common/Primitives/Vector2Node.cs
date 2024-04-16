using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Vector2", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/Vector2")]
    public class Vector2Node : BaseNode
    {
        [Input]
        [SerializeField]
        public float x;

        [Input]
        [SerializeField]
        public float y;

        [Output]
        public Vector2 result;

        protected override void Process()
        {
            result.x = x;
            result.y = y;
        }
    }
}
