using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GraphProcessor
{
    public class MiniMapView : MiniMap
	{
		public MiniMapView(BaseGraphView graphView) : this(graphView, new Vector2(200, 150))
		{

		}

		public MiniMapView(BaseGraphView baseGraphView,Vector2 size) : base()
		{
			graphView = baseGraphView;

			SetPosition(new Rect(0,0, size.x, size.y));

			base.capabilities |= Capabilities.Resizable;
		}
	}
}