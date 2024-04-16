using GraphProcessor;
using System;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("String To Int", new string[] { "converter", "common" })]
    [NodeMenuItem("Common/Converter/String To Int")]
    public class StringToIntNode : ConverterNode<string, int>
    {
        protected override void OnConvert()
        {
            if (int.TryParse(input, out output))
            {
                return;
            }
            output = 0;
        }
    }
}
