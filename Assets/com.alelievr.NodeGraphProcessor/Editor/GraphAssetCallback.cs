using UnityEditor;
using UnityEditor.Callbacks;

namespace GraphProcessor
{
    public static class GraphAssetCallback
    {
        [OnOpenAsset(0)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as GraphAsset;

            if (asset != null)
            {
                GraphWindow.OpenWindow(asset);
                return true;
            }

            return false;
        }
    }
}
