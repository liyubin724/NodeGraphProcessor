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

        private BaseGraph owner;

        [System.NonSerialized]
        public BaseNode inputNode;
        [System.NonSerialized]
        public NodePort inputPort;

        [System.NonSerialized]
        public BaseNode outputNode;
        [System.NonSerialized]
        public NodePort outputPort;

        //temporary object used to send port to port data when a custom input/output function is used.
        [System.NonSerialized]
        public object passThroughBuffer;

        public SerializableEdge() { }

        public static SerializableEdge CreateNewEdge(BaseGraph graph, NodePort inputPort, NodePort outputPort)
        {
            return new SerializableEdge
            {
                GUID = System.Guid.NewGuid().ToString(),
                owner = graph,
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
        public void Deserialize()
        {
            if (!owner.nodesPerGUID.ContainsKey(outputNodeGUID) || !owner.nodesPerGUID.ContainsKey(inputNodeGUID))
                return;

            outputNode = owner.nodesPerGUID[outputNodeGUID];
            inputNode = owner.nodesPerGUID[inputNodeGUID];
            inputPort = inputNode.GetPort(inputFieldName, inputPortIdentifier);
            outputPort = outputNode.GetPort(outputFieldName, outputPortIdentifier);
        }

        public override string ToString() => $"{outputNode.name}:{outputPort.fieldName} -> {inputNode.name}:{inputPort.fieldName}";
    }
}
