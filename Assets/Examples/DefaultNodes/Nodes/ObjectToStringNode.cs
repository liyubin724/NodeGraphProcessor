using GraphProcessor;

[System.Serializable,NodeMenuItem("Primitives/To String")]
[NodeIdentity("Object To String")]
public class ObjectToStringNode : BaseNode
{
    [Input(name = "Input")]
    public object input;

    [Output(name = "Output")]
    public string output;

    protected override void Process()
    {
        if(input != null)
        {
            output= input.ToString();
        }
        else
        {
            output = "null";
        }
    }
}
