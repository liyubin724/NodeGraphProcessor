using System.Reflection;
using UnityEngine;

namespace GraphProcessor
{
#if UNITY_EDITOR
    public abstract partial class BaseNode
    {
        public string displayName
        {
            get
            {
                if(!string.IsNullOrEmpty(customName))
                {
                    return customName;
                }

                var nodeAttr = GetType().GetCustomAttribute<NodeAttribute>();
                if (nodeAttr != null)
                {
                    return nodeAttr.name;
                }

                return name;
            }
        }

        public Texture icon
        {
            get
            {
                var nodeAttr = GetType().GetCustomAttribute<NodeAttribute>();
                if (nodeAttr == null || string.IsNullOrEmpty(nodeAttr.icon))
                {
                    return null;
                }

                return Resources.Load<Texture>(nodeAttr.icon);
            }
        }

        /// <summary>
		/// The accent color of the node
		/// </summary>
        public string color
        {
            get
            {
                var nodeAttr = GetType().GetCustomAttribute<NodeAttribute>();
                if (nodeAttr == null || string.IsNullOrEmpty(nodeAttr.color))
                {
                    return null;
                }

                var colorStr = nodeAttr.color;
                if(string.IsNullOrWhiteSpace(colorStr))
                {
                    return null;
                }
                if (!colorStr.StartsWith("#"))
                {
                    colorStr = "#" + colorStr;
                }
                return colorStr;
            }
        }

        /// <summary>
		/// Can the node be renamed in the UI. By default a node can be renamed by double clicking it's name.
		/// </summary>
        public bool isRenamable
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr != null)
                {
                    return attr.isRenamable;
                }

                return false;
            }
        }

        public bool isDeletable
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr != null)
                {
                    return attr.isDeletable;
                }

                return true;
            }
        }

        /// <summary>
		/// If the node can be locked or not
		/// </summary>
        public bool isUnlockable
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeCapabilityAttribute>();
                if (attr != null)
                {
                    return attr.isUnlockable;
                }

                return true;
            }
        }

        /// <summary>
		/// Set a custom uss file for the node. We use a Resources.Load to get the stylesheet so be sure to put the correct resources path
		/// https://docs.unity3d.com/ScriptReference/Resources.Load.html
		/// </summary>
        public string layoutStyle
        {
            get
            {
                var attr = GetType().GetCustomAttribute<NodeStyleAttribute>();
                if(attr == null)
                {
                    return null;
                }
                return attr.layoutStyle;
            }
        }
        /// <summary>
        /// Show the node controlContainer only when the mouse is over the node
        /// </summary>
        public bool showControlsOnHover
        {
            get
            {
                return false;
            }
        }
    }
#endif
}
