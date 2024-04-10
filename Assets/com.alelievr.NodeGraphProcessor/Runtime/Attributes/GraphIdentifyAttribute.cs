using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GraphIdentifyAttribute : Attribute
    {
        public string name { get; private set; }

        public string[] nodeTags { get; private set; }

        public GraphIdentifyAttribute(string name, params string[] nodeTags)
        {
            this.name = name;
            this.nodeTags = nodeTags;
        }
    }
}
