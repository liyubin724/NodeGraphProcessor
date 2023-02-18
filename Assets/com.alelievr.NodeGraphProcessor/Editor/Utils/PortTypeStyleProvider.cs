using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    public static class PortTypeStyleProvider
    {
        private static Dictionary<string,StyleSheet> sm_PortTypeStylesDic= new Dictionary<string, StyleSheet>();

        static PortTypeStyleProvider() 
        {
            var results = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.IsAbstract && type.IsSealed
                             from property in type.GetProperties()
                             let styleAttr = property.GetCustomAttribute<CustomPortTypeStyleAttribute>()
                             where styleAttr != null
                             let styleAssetPaths = (IList<string>)property.GetValue(null)
                             where styleAssetPaths != null && styleAssetPaths.Count > 0
                             from styleAssetPath in styleAssetPaths
                             let styleAsset = Resources.Load<StyleSheet>(styleAssetPath)
                             where styleAsset != null
                             select (assetPath: styleAssetPath, asset: styleAsset)
                            ).ToArray();
         
            if(results!=null && results.Length > 0 )
            {
                foreach(var result in results )
                { 
                    if (!sm_PortTypeStylesDic.ContainsKey(result.assetPath))
                    {
                        sm_PortTypeStylesDic.Add(result.assetPath, result.asset);
                    }
                } 
            }
        }

        public static StyleSheet[] GetStyleSheets()
        {
            return sm_PortTypeStylesDic.Values.ToArray();
        }
        
    }
}
