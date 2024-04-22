using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("String To Bool", new string[] { "converter", "common" })]
    [NodeMenuItem("Common/Converter/String To Bool")]
    public class StringToBoolNode : ConverterNode<string, bool>
    {
        protected override void OnConvert()
        {
            if (bool.TryParse(input, out bool result))
            {
                output = result;
            }
            else
            {
                output = false;
            }
        }
    }
}
