using GraphProcessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DotEngine.NodeGraph.Flow
{
    public class FlowGraphProcessor : BaseGraphProcessor
    {
        private List<StartFlowNode> startNodes;

        public FlowGraphProcessor(BaseGraph graph) : base(graph)
        {
        }

        public override void UpdateComputeOrder()
        {
            startNodes = graph.nodes.Where(n => n is StartFlowNode)
                                    .Select(n => n as StartFlowNode)
                                    .ToList();
        }

        public void Run(Action completeCallback)
        {
            Run();

            completeCallback?.Invoke();
        }

        public override void Run()
        {
            if(startNodes.Count == 0)
            {
                return;
            }

            Stack<BaseNode> nodeToExecute = new Stack<BaseNode>();
            startNodes.ForEach(s => nodeToExecute.Push(s));

            var enumerator = RunTheGraph(nodeToExecute);
            while (enumerator.MoveNext())
            {
                Debug.Log(enumerator.Current);
            };
        }

        private IEnumerator<BaseNode> RunTheGraph(Stack<BaseNode> nodeToExecute)
        {
            HashSet<BaseNode> nodeDependenciesGathered = new HashSet<BaseNode>();
            HashSet<BaseNode> skipConditionalHandling = new HashSet<BaseNode>();

            while (nodeToExecute.Count > 0)
            {
                var node = nodeToExecute.Pop();
                if (node is BaseFlowNode flowNode && !skipConditionalHandling.Contains(node))
                {
                    if (nodeDependenciesGathered.Contains(node))
                    {
                        node.OnProcess();
                        yield return node;

                        switch (node)
                        {
                            // special code path for the loop node as it will execute multiple times the same nodes
                            case ForLoopNode forLoopNode:
                                forLoopNode.index = forLoopNode.start - 1; // Initialize the start index
                                foreach (var n in forLoopNode.GetExecutedCompletedBody())
                                    nodeToExecute.Push(n);
                                for (int i = forLoopNode.start; i < forLoopNode.end; i++)
                                {
                                    foreach (var n in forLoopNode.GetExecutedCompletedBody())
                                        nodeToExecute.Push(n);

                                    nodeToExecute.Push(node); // Increment the counter
                                }

                                skipConditionalHandling.Add(node);
                                break;
                            // another special case for waitable nodes, like "wait for a coroutine", wait x seconds", etc.
                            //case WaitableNode waitableNode:
                            //    foreach (var n in waitableNode.GetExecutedNodes())
                            //        nodeToExecute.Push(n);

                            //    waitableNode.onProcessFinished += (waitedNode) =>
                            //    {
                            //        Stack<BaseNode> waitedNodes = new Stack<BaseNode>();
                            //        foreach (var n in waitedNode.GetExecuteAfterNodes())
                            //            waitedNodes.Push(n);
                            //        WaitedRun(waitedNodes);
                            //        waitableNode.onProcessFinished = null;
                            //    };
                            //    break;
                            //case IConditionalNode cNode:
                            //    foreach (var n in cNode.GetExecutedNodes())
                            //        nodeToExecute.Push(n);
                            //    break;
                            default:
                                Debug.LogError($"Conditional node {node} not handled");
                                break;
                        }

                        nodeDependenciesGathered.Remove(node);
                    }
                    else
                    {
                        nodeToExecute.Push(node);
                        nodeDependenciesGathered.Add(node);
                        foreach (var nonConditionalNode in flowNode.GetDependencyNodes())
                        {
                            nodeToExecute.Push(nonConditionalNode);
                        }
                    }
                }
                else
                {
                    node.OnProcess();
                    yield return node;
                }
            }
        }
    }
}
