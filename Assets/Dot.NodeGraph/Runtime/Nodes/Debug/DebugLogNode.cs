using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.NodeGraph
{
    [Serializable]
    [Node("Debug Log")]
    [NodeTag("debug")]
    [NodeMenuItem("Debug/Log")]
    public class DebugLogNode : BaseNode
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
            var message = string.Format(format, target);
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
