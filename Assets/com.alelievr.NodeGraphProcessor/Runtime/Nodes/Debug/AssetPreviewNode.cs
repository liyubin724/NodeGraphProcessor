using GraphProcessor;
using UnityObject = UnityEngine.Object;

namespace GraphProcessor
{
    [System.Serializable, NodeMenuItem("Debug/Asset Preview")]
    [NodeIdentity("AssetPreview")]
    public class AssetPreviewNode : BaseNode
    {
        [Input(name = "input")]
        public UnityObject input;
    }
}