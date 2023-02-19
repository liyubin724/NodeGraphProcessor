using GraphProcessor;
using UnityObject = UnityEngine.Object;

[System.Serializable, NodeMenuItem("Debug/Asset Preview")]
[NodeIdentity("AssetPreview")]
public class AssetPreviewNode : BaseNode
{
    [Input(name ="input")]
    public UnityObject input;
}
