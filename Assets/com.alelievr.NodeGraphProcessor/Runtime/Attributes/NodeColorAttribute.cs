using System;
using UnityEngine;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NodeColorAttribute : Attribute
    {
        public Color color { get; private set; }

        public NodeColorAttribute(Color color)
        {
            this.color = color;
        }
    }
}
