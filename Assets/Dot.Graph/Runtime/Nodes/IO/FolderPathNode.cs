using GraphProcessor;
using System;
using UnityEngine;

namespace DotEngine.Graph
{
    [Serializable]
    [NodeIdentity("Folder Path", new string[] { "io", "common" })]
    [NodeMenuItem("Common/IO/Folder Path")]
    public class FolderPathNode : BaseNode
    {
        [Output]
        [SerializeField]
        public string path;

        [SerializeField]
        public bool isRelativeToAssets = true;
    }
}

