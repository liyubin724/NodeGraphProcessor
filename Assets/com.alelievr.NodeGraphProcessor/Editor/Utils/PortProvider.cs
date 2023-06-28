using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    public static class PortProvider
    {
        private static Dictionary<string,StyleSheet> sm_PortTypeDic = new Dictionary<string, StyleSheet>();

        static PortProvider()
        {
            BuildPortTypeStyle();
        }

        public static StyleSheet[] GetTypeStyles()
        {
            return sm_PortTypeDic.Values.ToArray();
        }

        private static void BuildPortTypeStyle()
        {
            var results = (
                           from assembly in AppDomain.CurrentDomain.GetAssemblies()
                           from type in assembly.GetTypes()
                           where type.IsAbstract && type.IsSealed
                           from property in type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                           let styleAttr = property.GetCustomAttribute<PortCustomStyleAttribute>()
                           where styleAttr != null
                           let styleAssetPaths = (IList<string>)property.GetValue(null)
                           where styleAssetPaths != null && styleAssetPaths.Count > 0
                           from styleAssetPath in styleAssetPaths
                           let styleAsset = Resources.Load<StyleSheet>(styleAssetPath)
                           where styleAsset != null
                           select (assetPath: styleAssetPath, asset: styleAsset)
                          ).ToArray();

            sm_PortTypeDic.Clear();

            if (results != null && results.Length > 0)
            {
                foreach (var result in results)
                {
                    if (!sm_PortTypeDic.ContainsKey(result.assetPath)) 
                    {
                        sm_PortTypeDic.Add(result.assetPath, result.asset);
                    }
                }
            }
        }

        [PortCustomStyle]
        public static List<string> CustomPortTypeStyle
        {
            get
            {
                return new List<string>
                {
                    "GraphProcessorStyles/PortTypeView"
                };
            }
        }
    }
}
