using GraphProcessor;
using System.Collections.Generic;

public static class PortStyleDefine
{
    [CustomPortTypeStyle]
    public static List<string> GetStyleAssets
    {
        get
        {
            return new List<string>()
            {
                "AssetImporter_PortViewTypes"
            };
        }
    }
}
