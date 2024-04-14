using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace DotEditor.AssetSettings
{
    public class AssetSettingWindow : BaseGraphWindow
    {
        [MenuItem("Dot/Asset Setting/Setting Window")]
        public static void OpenWithTmpGraph()
        {
            var win = CreateWindow<AssetSettingWindow>("Asset Setting");

            var graph = CreateInstance<AssetSettingGraph>();
            graph.hideFlags = HideFlags.HideAndDontSave;
            win.InitializeGraph(graph);

            win.Show();
        }


        protected override void InitializeWindow(BaseGraph graph)
        {
            if (graphView == null)
            {
                graphView = new AssetSettingGraphView(this);
            }

            rootView.Add(graphView);
        }
    }
}
