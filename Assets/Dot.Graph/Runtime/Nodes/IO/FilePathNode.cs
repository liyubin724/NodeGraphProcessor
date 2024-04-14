using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("File Path", new string[] { "io", "common" })]
    [NodeMenuItem("Common/IO/File Path")]
    public class FilePathNode : BaseNode
    {
        [Output]
        [SerializeField]
        public string path;

        [SerializeField]
        public bool isRelativeToAssets = true;
    }
}
