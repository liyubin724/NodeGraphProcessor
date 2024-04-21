using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace DotEditor.Graph.Assets
{
    public abstract class AssetSettingNode : BaseNode
    {

        protected override void Process()
        {
            base.Process();

            var importer = AssetImporter.GetAtPath("") as TextureImporter;
        }
    }
}
