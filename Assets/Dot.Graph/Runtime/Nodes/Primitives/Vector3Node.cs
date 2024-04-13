using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Vector3", new string[] { "primitives", "common" })]
    [NodeMenuItem("Common/Primitives/Vector3")]
    public class Vector3Node : BaseNode
    {
        [Input]
        [SerializeField]
        public float x;

        [Input]
        [SerializeField]
        public float y;

        [Input]
        [SerializeField]
        public float z;

        [Output]
        public Vector3 result;

        protected override void Process()
        {
            result.x = x;
            result.y = y;
            result.z = z;
        }
    }
}
