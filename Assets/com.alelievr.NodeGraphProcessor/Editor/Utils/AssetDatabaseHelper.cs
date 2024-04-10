using System;
using System.IO;
using UnityEditor;

namespace GraphProcessor
{
    public static class AssetDatabaseHelper
    {
        public static MonoScript FindScriptFromClassName(string className)
        {
            var scriptGUIDs = AssetDatabase.FindAssets($"t:script {className}");

            if (scriptGUIDs.Length == 0)
                return null;

            foreach (var scriptGUID in scriptGUIDs)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(scriptGUID);
                var script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);

                if (script != null && string.Equals(className, Path.GetFileNameWithoutExtension(assetPath), StringComparison.OrdinalIgnoreCase))
                    return script;
            }

            return null;
        }
    }
}
