using System;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GraphIdentifyAttribute : Attribute
    {
        public string name { get; private set; }

        /// <summary>
        /// the tag of node
        /// </summary>
        public string[] includeTags { get; private set; }
        public string[] excludeTags { get; private set; }

        public GraphIdentifyAttribute(string name, string[] includeTags = null, string[] excludeTags = null)
        {
            this.name = name;
            this.includeTags = includeTags;
            this.excludeTags = excludeTags;
        }
    }
}
