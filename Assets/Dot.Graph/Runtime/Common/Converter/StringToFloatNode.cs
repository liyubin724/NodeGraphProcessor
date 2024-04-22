using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("String To Float", new string[] { "converter", "common" })]
    [NodeMenuItem("Common/Converter/String To Float")]
    public class StringToFloatNode : ConverterNode<string, float>
    {
        protected override void OnConvert()
        {
            if (float.TryParse(input, out output))
            {
                return;
            }
            output = 0.0f;
        }
    }
}
