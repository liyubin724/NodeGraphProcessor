using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using GraphProcessor;

[CustomNodeEditorAttribute(typeof(ColorNode))]
public class ColorNodeView : BaseNodeView
{
	public override void Enable()
	{
		AddControlField(nameof(ColorNode.color));
		style.width = 200;
	}
}