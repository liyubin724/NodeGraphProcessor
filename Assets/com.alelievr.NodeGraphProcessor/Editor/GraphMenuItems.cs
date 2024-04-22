using UnityEditor;
using UnityEngine;

namespace GraphProcessor
{
    public static class GraphMenuItems
    {
        [MenuItem("Assets/Create/Graphs/Node C# Script", false, 0)]
        private static void CreateNodeCSharpScritpt()
        {
            NodeGraphProcessorMenuItems.CreateDefaultNodeCSharpScritpt();
        }

        [MenuItem("Assets/Create/Graphs/Node View C# Script", false, 1)]
        private static void CreateNodeViewCSharpScritpt()
        {
            NodeGraphProcessorMenuItems.CreateDefaultNodeViewCSharpScritpt();
        }

        [MenuItem("Assets/Create/Graphs/Default Graph Asset", false, 10)]
        public static void CreateGraphAsset()
        {
            var graph = ScriptableObject.CreateInstance<GraphAsset>();
            ProjectWindowUtil.CreateAsset(graph, "default-graph.asset");
        }

    }
}
