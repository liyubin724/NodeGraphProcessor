using GraphProcessor;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, NodeMenuItem("Custom/PortData")]
[NodeIdentity("Port Data")]
public class CustomPortData : BaseNode
{
    [Input(name = "In Values", allowMultiple = true)]
    public IEnumerable<object> inputs = null;

    static PortData[] portDatas = new PortData[] {
        new PortData{displayName = "0", displayType = typeof(float), identifier = "0"},
        new PortData{displayName = "1", displayType = typeof(int), identifier = "1"},
        new PortData{displayName = "2", displayType = typeof(GameObject), identifier = "2"},
        new PortData{displayName = "3", displayType = typeof(Texture2D), identifier = "3"},
    };

    [Output]
    public float output;

    protected override void Process()
    {
        output = 0;

        if (inputs == null)
            return;

        foreach (float input in inputs)
            output += input;
    }

    [CustomPortBehavior(nameof(inputs))]
    IEnumerable<PortData> GetPortsForInputs(List<SerializableEdge> edges)
    {
        foreach (var portData in portDatas)
        {
            yield return portData;
        }
    }

    [CustomPortInput(nameof(inputs), typeof(float), allowCast = true)]
    public void GetInputs(List<SerializableEdge> edges)
    {
        // inputs = edges.Select(e => (float)e.passThroughBuffer);
    }
}
