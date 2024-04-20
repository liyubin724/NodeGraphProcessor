using GraphProcessor;
using System;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    [Serializable]
    [NodeIdentity("Texture Importer(Editor)", new string[] { "editor", "importer", "asset" })]
    [NodeMenuItem("Assets/Importers/Texture Importer(In Editor)")]
    public class TextureImporterNode : AssetImporterNode<TextureImporter>
    {
    }
}
