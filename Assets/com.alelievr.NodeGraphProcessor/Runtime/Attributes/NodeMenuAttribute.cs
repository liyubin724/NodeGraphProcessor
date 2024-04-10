using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class NodeMenuAttribute : Attribute
    {
        public string menuName { get; private set; }
        public bool enable { get; set; } = true;

        public NodeMenuAttribute(string menuName)
        {
            this.menuName = menuName;
        }
    }
}
