using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NodeCapabilityAttribute : Attribute
    {
        public bool deletable { get; set; } = true;
        public bool renamable { get; set; } = false;
        public bool unlockable { get; set; } = true;
    }
}
