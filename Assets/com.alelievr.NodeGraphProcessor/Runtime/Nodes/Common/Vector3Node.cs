using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Vector3")]
    [NodeIdentity("Vector3")]
    public class Vector3Node : BaseNode
    {
        [Input("x"), ShowAsDrawer]
        public float inputX;
        [Input("y"), ShowAsDrawer]
        public float inputY;
        [Input("z"), ShowAsDrawer]
        public float inputZ;

        [Output("vec3")]
        public Vector3 output;

        protected override void Process()
        {
            output = new Vector3(inputX, inputY, inputZ);
        }
    }
}