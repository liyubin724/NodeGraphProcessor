using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/Game Object")]
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
