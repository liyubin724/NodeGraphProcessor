using GraphProcessor;
using System;
using UnityObject = UnityEngine.Object;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("UObject Preview", new string[] { "debug", "common" })]
    [NodeMenuItem("Common/Debug/UObject Preview")]
    public class UObjectPreviewNode : BaseNode
    {
        [Input]
        public UnityObject uObj;
    }
}
