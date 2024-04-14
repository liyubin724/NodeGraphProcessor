using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace DotEditor.AssetSettings
{
    public class AssetSettingGraphView : BaseGraphView
    {
        public AssetSettingGraphView(EditorWindow window) : base(window)
        {
        }

        public override bool FilterCreateNodeMenuEntry(string path, Type nodeType)
        {
            var identityAttr = nodeType.GetCustomAttribute<NodeIdentityAttribute>();
            if (identityAttr == null || identityAttr.tags == null || identityAttr.tags.Length == 0)
            {
                return false;
            }

            return base.FilterCreateNodeMenuEntry(path, nodeType);
        }
    }
}
