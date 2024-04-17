using DotEngine.Graph;
using GraphProcessor;
using UnityEngine.UIElements;

namespace DotEditor.Graph
{
    [CustomNodeEditor(typeof(DisplayNode))]
    public class DisplayNodeView : BaseNodeView
    {
        private Label m_Label;
        private DisplayNode m_Node;

        public override void Enable()
        {
            m_Node = nodeTarget as DisplayNode;

            m_Label = new Label("Value");
            controlsContainer.Add(m_Label);

            nodeTarget.onProcessed += OnValueChanged;
            onPortConnected += (p) => OnValueChanged();
            onPortDisconnected += (p) => OnValueChanged();

            OnValueChanged();
        }

        private void OnValueChanged()
        {
            if (m_Node.value != null)
            {
                m_Label.text = m_Node.value.ToString();
            }
            else
            {
                m_Label.text = "null";
            }
        }
    }
}

