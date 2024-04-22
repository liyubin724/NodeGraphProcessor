using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class CustomGraphWindowAttribute : Attribute
    {
        public Type graphType { get; private set; }

        public CustomGraphWindowAttribute(Type graphType)
        {
            this.graphType = graphType;
        }
    }
}
