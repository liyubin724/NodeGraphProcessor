using GraphProcessor;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Common/Vector2")]
    [NodeIdentity("Vector2")]
    public class Vector2Node : BaseNode
    {
        [Input("x"), ShowAsDrawer]
        public float inputX;
        [Input("y"), ShowAsDrawer]
        public float inputY;

        [Output("vec2")]
        public Vector2 output;

        protected override void Process()
        {
            output = new Vector2(inputX, inputY);
        }
    }
}