using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class NodeIdentityAttribute : Attribute
    {
        public string name { get; private set; }
        public bool enable { get; set; } = true;
        public bool canProcess { get; set; } = true;
        public bool showControlsOnHover { get; set; } = false;

        public string[] tags { get; private set; }

        public NodeIdentityAttribute(string name, params string[] tags)
        {
            this.name = name;
            this.tags = tags;
        }
    }
}
