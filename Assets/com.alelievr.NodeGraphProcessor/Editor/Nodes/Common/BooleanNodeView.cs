using GraphProcessor;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    [NodeCustomEditor(typeof(BooleanNode))]
    public class BooleanNodeView : BaseNodeView
    {
        public override void Enable()
        {
            var node = nodeTarget as BooleanNode;

            var toggleField = new Toggle("Value") { value = node.output };
            toggleField.RegisterValueChangedCallback((evt) =>
            {
                owner.RegisterCompleteObjectUndo("Editor bool node");
                node.output = evt.newValue;
            });
            controlsContainer.Add(toggleField);
        }
    }
}