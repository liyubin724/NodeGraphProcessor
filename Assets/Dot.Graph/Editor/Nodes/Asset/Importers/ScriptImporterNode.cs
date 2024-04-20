using DotEditor.Graph.Assets;
using GraphProcessor;
using System;
using UnityEditor.AssetImporters;

namespace DotEngine.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Script Importer(Editor)", new string[] { "editor", "importer", "asset" })]
    [NodeMenuItem("Assets/Importers/Script Importer(In Editor)")]
    public class ScriptImporterNode : AssetImporterNode<ScriptedImporter>
    {
    }
}
