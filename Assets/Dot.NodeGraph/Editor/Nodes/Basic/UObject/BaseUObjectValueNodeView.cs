using DotEngine.NodeGraph;
using GraphProcessor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace DotEditor.NodeGraph
{
    public abstract class BaseUObjectValueNodeView<TUObject> : BaseNodeView where TUObject : UnityObject
    {
        public override void Enable()
        {
            var node = nodeTarget as BaseUObjectValueNode<TUObject>;

            var imageField = new Image();
            if (node.value != null)
            {
                imageField.image = AssetPreview.GetAssetPreview(node.value);
            }
            controlsContainer.Add(imageField);

            var uObjectField = new ObjectField("value");
            uObjectField.objectType = typeof(TUObject);
            uObjectField.RegisterValueChangedCallback(evt =>
            {
                node.value = (TUObject)evt.newValue;

                imageField.image = AssetPreview.GetAssetPreview(node.value);
            });
            uObjectField.value = node.value;
            controlsContainer.Add(uObjectField);
        }

    }
}
