using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine.UIElements;

namespace DotEditor.Graph.Assets
{
    [CustomPropertyDrawer(typeof(SpriteSettingData))]
    public class SpriteSettingDataPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var containerView = new VisualElement();

            SerializedProperty pixelsPerUnitProperty = property.FindPropertyRelative(nameof(SpriteSettingData.pixelsPerUnit));
            SerializedProperty meshTypeProperty = property.FindPropertyRelative(nameof(SpriteSettingData.meshType));
            SerializedProperty sRGBTextureProperty = property.FindPropertyRelative(nameof(SpriteSettingData.sRGBTexture));
            SerializedProperty alphaSourceProperty = property.FindPropertyRelative(nameof(SpriteSettingData.alphaSource));
            SerializedProperty alphaIsTransparencyProperty = property.FindPropertyRelative(nameof(SpriteSettingData.alphaIsTransparency));



            return containerView;
        }
    }
}
