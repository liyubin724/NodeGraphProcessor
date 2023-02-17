using GraphProcessor;
using UnityEngine.UIElements;

[NodeCustomEditor(typeof(ConvertToStringNode))]
public class ConvertToStringNodeView : BaseNodeView
{
    Label resultLabel;
    ConvertToStringNode node;
    public override void Enable()
    {
        node = nodeTarget as ConvertToStringNode;

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
