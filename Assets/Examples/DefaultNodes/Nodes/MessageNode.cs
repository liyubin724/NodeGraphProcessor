using GraphProcessor;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/MessageNode")]
[NodeIdentity("Message Node")]
public class MessageNode : BaseNode
{
    const string k_InputIsNot42Error = "Input is not 42 !";

    [Input(name = "In")]
    public float input;

    [Setting("Message Type")]
    public NodeMessageType messageType = NodeMessageType.Error;

    protected override void Process()
    {
        if (input != 42)
            AddMessage(k_InputIsNot42Error, messageType);
        else
            RemoveMessage(k_InputIsNot42Error);
    }
}
