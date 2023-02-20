using GraphProcessor;

namespace GraphProcessor
{
    [NodeCustomEditor(typeof(ColorNode))]
    public class ColorNodeView : BaseNodeView
    {
        public override void Enable()
        {
            AddControlField(nameof(ColorNode.value));
            style.width = 200;
        }
    }
}