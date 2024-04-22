using GraphProcessor;

namespace DotEditor.Graph.Assets
{
    [CustomGraphWindow(typeof(AssetSettingGraph))]
    public class AssetSettingGraphWindow : GraphWindow
    {
        private bool m_ProcessorVisible = false;
        protected override void OnRefreshToolbarView(EnhancedToolbarView toolbarView)
        {
            toolbarView.AddRightToggle("Show Processor", m_ProcessorVisible, (v) =>
            {
                graphView.ToggleView<ProcessorView>();
            });
        }
    }
}
