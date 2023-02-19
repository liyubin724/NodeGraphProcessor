using System.Collections.Generic;

namespace GraphProcessor
{
    public static class PortDefine
    {
        [CustomPortTypeStyle]
        public static List<string> PortStyleSheets
        {
            get
            {
                return new List<string>() {
                    "GraphProcessorStyles/PortTypeView"
                };
            }
        }
    }
}
