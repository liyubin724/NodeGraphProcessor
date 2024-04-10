using GraphProcessor;
using UnityEngine;

public abstract class AbstractNode : BaseNode
{
    [Input(name = "In")]
    public float input;

    [Output(name = "Out")]
    public float output;

    protected override void Process()
    {
        output = input * 42;
    }
}

[System.Serializable, NodeMenuItem("Custom/Abstract Child1")]
[NodeIdentity("Abstract Node Child 1")]
public class AbstractNodeChild1 : AbstractNode { }

[System.Serializable, NodeMenuItem("Custom/Abstract Child2")]
[NodeIdentity("Abstract Node Child 2")]
public class AbstractNodeChild2 : AbstractNode { }
