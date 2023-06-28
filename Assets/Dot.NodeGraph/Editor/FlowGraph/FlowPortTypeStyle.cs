using GraphProcessor;
using System.Collections.Generic;

namespace DotEditor.NodeGraph
{
    public static class FlowPortTypeStyle
    {
        [PortCustomStyle]
        public static List<string> GetStyles
        {
            get 
            {
                return new List<string> 
                {
                    "Styles/FlowPortTypeView"
                };
            }
        }
    }
}
