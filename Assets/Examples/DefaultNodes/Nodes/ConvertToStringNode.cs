using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable,NodeMenuItem("Primitives/To String")]
[NodeIdentity("ToString")]
public class ConvertToStringNode : BaseNode
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
