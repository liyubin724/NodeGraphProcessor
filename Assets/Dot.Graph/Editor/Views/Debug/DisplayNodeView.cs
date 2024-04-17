using DotEngine.Graph;
using GraphProcessor;
using System.Collections;
using System.Text;
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
                if (m_Node.value is IList list)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < list.Count; i++)
                    {
                        builder.AppendLine($"{i}: {list[i].ToString()}");
                    }
                    m_Label.text = builder.ToString();
                }
                else
                {
                    m_Label.text = m_Node.value.ToString();
                }
            }
            else
            {
                m_Label.text = "null";
            }
        }
    }
}

