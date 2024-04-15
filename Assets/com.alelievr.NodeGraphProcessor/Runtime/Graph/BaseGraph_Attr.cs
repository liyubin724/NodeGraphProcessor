using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphProcessor
{
    public partial class BaseGraph
    {
        public string[] includeNodeTags
        {
            get
            {
                var attr = GetType().GetCustomAttribute<GraphIdentifyAttribute>();
                if (attr == null)
                {
                    return new string[0];
                }

                return attr.includeTags;
            }
        }

        public string[] excludeNodeTags
        {
            get
            {
                var attr = GetType().GetCustomAttribute<GraphIdentifyAttribute>();
                if (attr == null)
                {
                    return new string[0];
                }

                return attr.excludeTags;
            }
        }

        /// <summary>
        /// Set a custom uss file for the graph. 
        /// We use a Resources.Load to get the stylesheet so be sure to put the correct resources path
        /// </summary>
        //public string[] layoutStyles
        //{
        //    get
        //    {
        //        var attrs = GetType().GetCustomAttributes<GraphLayoutStyleAttribute>();

        //        List<string> styles = new List<string>();
        //        foreach (var attr in attrs)
        //        {
        //            if (!string.IsNullOrEmpty(attr.stylePath))
        //            {
        //                styles.Add(attr.stylePath);
        //            }
        //        }

        //        return styles.ToArray();
        //    }
        //}
    }
}
