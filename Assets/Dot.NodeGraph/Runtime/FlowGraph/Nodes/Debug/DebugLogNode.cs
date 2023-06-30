using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph.Flow
{
    [Serializable]
    [NodeMenuItem("Flow/Debug/Debug Log")]
    [Node("Log")]
    [NodeTag("flow")]
    public class DebugLogNode : BaseLinearFlowNode
    {
        [Input("Target")]
        public object target;

        [Input("Format")]
        [SerializeField]
        public string messageFormat;

        public LogType logType = LogType.Log;

        protected override void Process()
        {
            var format = string.IsNullOrEmpty(messageFormat) ? "{0}" : messageFormat;
            var message = string.Format(format, target??"null");
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Assert:
                case LogType.Error:
                case LogType.Exception:
                    Debug.LogError(message);
                    break;
            }
        }
    }
}
