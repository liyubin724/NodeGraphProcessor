using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph.Flow
{
    [Serializable]
    [CreateAssetMenu(fileName ="flow_graph.asset",menuName = "Node Graph/Flow")]
    [GraphCompatibleTag("basic","flow", "debug","condition")]
    public class FlowGraph : BaseGraph
    {

    }
}
