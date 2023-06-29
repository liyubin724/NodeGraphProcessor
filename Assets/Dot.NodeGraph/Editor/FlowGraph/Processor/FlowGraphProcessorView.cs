using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace DotEngine.NodeGraph.Flow
{
    public class FlowGraphProcessorView : PinnedElementView
    {
        BaseGraphProcessor processor;

        public FlowGraphProcessorView()
        {
            title = "Processor Panel";
        }

        protected override void Initialize(BaseGraphView graphView)
        {
            processor = new FlowGraphProcessor(graphView.graph);
            graphView.computeOrderUpdated += processor.UpdateComputeOrder;

            Button playBtn = new Button(OnPlay) { name = "ActionButton", text = "Play !" };
            content.Add(playBtn);
        }

        void OnPlay()
        {
            processor.Run();
        }
    }
}
