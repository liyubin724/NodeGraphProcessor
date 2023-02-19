using GraphProcessor;
using UnityEngine.UIElements;

[NodeCustomEditor(typeof(ObjectToStringNode))]
public class ObjectToStringNodeView : BaseNodeView
{
    Label resultLabel;
    ObjectToStringNode node;
    public override void Enable()
    {
        node = nodeTarget as ObjectToStringNode;

        resultLabel = new Label();
        controlsContainer.Add(resultLabel);

        nodeTarget.onProcessed += UpdateResultLabel;
        onPortConnected += (p) => UpdateResultLabel();
        onPortDisconnected+= (p) => UpdateResultLabel();

        UpdateResultLabel();
    }

    void UpdateResultLabel()
    {
        if(string.IsNullOrEmpty(node.output))
        {
            resultLabel.text = string.Empty;
        }
        else
        {
            resultLabel.text = node.output;
        }
    }
}
