using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class NodeLayoutStyleAttribute : Attribute
    {
        public string stylePath { get; private set; }
        public NodeLayoutStyleAttribute(string stylePath)
        {
            this.stylePath = stylePath;
        }
    }
}
