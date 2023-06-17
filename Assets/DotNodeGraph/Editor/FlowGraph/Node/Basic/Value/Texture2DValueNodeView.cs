using DotEngine.NodeGraph;
using GraphProcessor;
using UnityEngine;

namespace DotEditor.NodeGraph
{
    [NodeCustomEditor(typeof(Texture2DValueNode))]
    public class Texture2DValueNodeView : BaseUObjectValueNodeView<Texture2D>
    {
    }
}
