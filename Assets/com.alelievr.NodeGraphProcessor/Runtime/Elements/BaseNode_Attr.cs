using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GraphProcessor
{
    public abstract partial class BaseNode
    {
        /// <summary>
        /// Name of the node, it will be displayed in the title section
        /// </summary>
        /// <returns></returns>
        public virtual string name
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeIdentityAttribute>();
                if (attr != null && !string.IsNullOrEmpty(attr.name))
                {
                    return attr.name;
                }

                return GetType().Name;
            }
        }

        public string displayName
        {
            get
            {
                if (!string.IsNullOrEmpty(customName))
                {
                    return customName;
                }

                return name;
            }
        }

        /// <summary>
        /// The accent color of the node
        /// </summary>
        public Color color
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeColorAttribute>();
                if (attr == null)
                {
                    return Color.clear;
                }

                return attr.color;
            }
        }

        /// <summary>
        /// Set a custom uss file for the node. 
        /// We use a Resources.Load to get the stylesheet so be sure to put the correct resources path
        /// </summary>
        public string[] layoutStyles
        {
            get
            {
                var attrs = GetType().GetCustomAttributes<NodeLayoutStyleAttribute>();

                List<string> styles = new List<string>();
                foreach (var attr in attrs)
                {
                    if (!string.IsNullOrEmpty(attr.stylePath))
                    {
                        styles.Add(attr.stylePath);
                    }
                }

                return styles.ToArray();
            }
        }

        /// <summary>
        /// Tell wether or not the node can be processed. 
        /// Do not check anything from inputs because this step happens before inputs are sent to the node
        /// </summary>
        public bool canProcess
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeIdentityAttribute>();
                if (attr == null)
                {
                    return false;
                }
                return attr.canProcess;
            }
        }

        /// <summary>
        /// Show the node controlContainer only when the mouse is over the node
        /// </summary>
        public bool showControlsOnHover
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeIdentityAttribute>();
                if (attr == null)
                {
                    return false;
                }
                return attr.showControlsOnHover;
            }
        }

        /// <summary>
        /// If the node can be locked or not
        /// </summary>
        public bool unlockable
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr == null)
                {
                    return true;
                }

                return attr.unlockable;
            }
        }


        /// <summary>
        /// True if the node can be deleted, false otherwise
        /// </summary>
        public bool deletable
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr == null)
                {
                    return true;
                }

                return attr.deletable;
            }
        }

        /// <summary>
        /// Can the node be renamed in the UI. 
        /// By default a node can be renamed by double clicking it's name.
        /// </summary>
        public bool renamable
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr == null)
                {
                    return false;
                }

                return attr.renamable;
            }
        }

        public bool needInspector
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr == null)
                {
                    return false;
                }

                return attr.needInspector;
            }
        }
    }
}
