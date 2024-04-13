using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Console Log", new string[] { "debug", "common" })]
    [NodeMenuItem("Common/Debug/Console Log")]
    public class ConsoleLogNode : BaseNode
    {
        [Input]
        public object value;

        [Input]
        [SerializeField]
        [Tooltip("The format of message")]
        public string format;

        public LogType logType = LogType.Log;

        protected override void Process()
        {
            var formatStr = string.IsNullOrEmpty(format) ? "{0}" : format;
            var v = value ?? "null";

            var message = string.Format(formatStr, v);
            if (logType == LogType.Error)
            {
                Debug.LogError(message);
            }
            else if (logType == LogType.Warning)
            {
                Debug.LogWarning(message);
            }
            else
            {
                Debug.Log(message);
            }
        }
    }
}
