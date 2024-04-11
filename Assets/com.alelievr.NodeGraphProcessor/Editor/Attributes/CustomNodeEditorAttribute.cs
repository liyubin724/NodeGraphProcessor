using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomNodeEditorAttribute : Attribute
    {
        public Type nodeType { get; private set; }

        public CustomNodeEditorAttribute(Type nodeType)
        {
            this.nodeType = nodeType;
        }
    }
}