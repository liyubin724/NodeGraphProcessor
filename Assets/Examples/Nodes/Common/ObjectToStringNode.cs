using GraphProcessor;

[System.Serializable,NodeMenuItem("Common/Object To String")]
[NodeIdentity("Object To String")]
public class ObjectToStringNode : BaseNode
{
    [Input(name = "obj")]
    public object input;

    [Output(name = "str")]
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
