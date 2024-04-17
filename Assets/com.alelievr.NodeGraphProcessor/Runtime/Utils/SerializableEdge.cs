using System;
using UnityEngine;

namespace GraphProcessor
{
    [System.Serializable]
    public class SerializableEdge : ISerializationCallbackReceiver
    {
        public string GUID;

        [SerializeField]
        string inputNodeGUID;
        [SerializeField]
        string outputNodeGUID;

        public string inputFieldName;
        public string outputFieldName;

        // Use to store the id of the field that generate multiple ports
        public string inputPortIdentifier;
        public string outputPortIdentifier;

        [NonSerialized]
        public BaseGraph graph;

        [NonSerialized]
        public BaseNode inputNode;
        [NonSerialized]
        public NodePort inputPort;

        [NonSerialized]
        public BaseNode outputNode;
        [NonSerialized]
        public NodePort outputPort;

        //temporary object used to send port to port data when a custom input/output function is used.
        [NonSerialized]
        public object passThroughBuffer;

        public SerializableEdge() { }

        public static SerializableEdge CreateNewEdge(BaseGraph graph, NodePort inputPort, NodePort outputPort)
        {
            return new SerializableEdge
            {
                GUID = System.Guid.NewGuid().ToString(),
                graph = graph,
                inputNode = inputPort.owner,
                inputFieldName = inputPort.fieldName,
                outputNode = outputPort.owner,
                outputFieldName = outputPort.fieldName,
                inputPort = inputPort,
                outputPort = outputPort,
                inputPortIdentifier = inputPort.portData.identifier,
                outputPortIdentifier = outputPort.portData.identifier
            };
        }

        public void OnBeforeSerialize()
        {
            if (outputNode == null || inputNode == null)
                return;

            outputNodeGUID = outputNode.GUID;
            inputNodeGUID = inputNode.GUID;
        }

        public void OnAfterDeserialize() { }

        //here our owner have been deserialized
        public void Deserialize(BaseGraph graph)
        {
            this.graph = graph;

            if (!graph.nodesPerGUID.ContainsKey(outputNodeGUID) || !graph.nodesPerGUID.ContainsKey(inputNodeGUID))
                return;

            outputNode = graph.nodesPerGUID[outputNodeGUID];
            inputNode = graph.nodesPerGUID[inputNodeGUID];
            inputPort = inputNode.GetPort(inputFieldName, inputPortIdentifier);
            outputPort = outputNode.GetPort(outputFieldName, outputPortIdentifier);
        }

        public override string ToString() => $"{outputNode.name}:{outputPort.fieldName} -> {inputNode.name}:{inputPort.fieldName}";
    }
}
