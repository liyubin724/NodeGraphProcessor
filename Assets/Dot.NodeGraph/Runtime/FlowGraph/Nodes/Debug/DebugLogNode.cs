using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph.Flow
{
    [Serializable]
    [NodeMenuItem("Flow/Debug/Log")]
    public class DebugLogNode : BaseLinearFlowNode
    {
        [Input("Message")]
        [SerializeField]
        public string message;

        public LogType logType = LogType.Log;

        protected override void Process()
        {
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Error:
                case LogType.Exception:
                    Debug.LogError(message);
                    break;
                case LogType.Assert:
                    Debug.Assert(message != null);
                    break;
            }
        }
    }
}
