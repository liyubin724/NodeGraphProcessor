using UnityEditor;
using UnityEngine;

namespace GraphProcessor
{
    public static class GraphMenuItems
    {
        [MenuItem("Assets/Create/Graphs/Default Graph Asset", false, 10)]
        public static void CreateGraphAsset()
        {
            var graph = ScriptableObject.CreateInstance<GraphAsset>();
            ProjectWindowUtil.CreateAsset(graph, "default-graph.asset");
        }
    }
}
