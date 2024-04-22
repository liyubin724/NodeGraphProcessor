using UnityEditor;
using UnityEditor.Callbacks;

namespace GraphProcessor
{
    public static class GraphCallback
    {
        [OnOpenAsset(1)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as BaseGraph;

            if (asset != null)
            {
                GraphWindow.OpenWindow(asset);
                return true;
            }
            return false;
        }
    }
}
