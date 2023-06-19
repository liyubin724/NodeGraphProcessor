using DotEngine.NodeGraph;
using GraphProcessor;
using UnityEngine;

namespace DotEditor.NodeGraph
{
    [NodeCustomEditor(typeof(GameObjectValueNode))]
    public class GameObjectValueNodeView : BaseUObjectValueNodeView<GameObject>
    {
    }
}
