using UnityEngine.UIElements;
using GraphProcessor;

namespace GraphProcessor
{
    [NodeCustomEditor(typeof(FloatNode))]
    public class FloatNodeView : BaseNodeView
    {
        public override void Enable()
        {
            var floatNode = nodeTarget as FloatNode;

            var floatField = new FloatField("Value") { value = floatNode.output };
            floatField.style.width = 200;
            floatField.RegisterValueChangedCallback(evt =>
            {
                owner.RegisterCompleteObjectUndo("Editor float node");
                floatNode.output = evt.newValue;
            });
            controlsContainer.Add(floatField);
        }
    }
}