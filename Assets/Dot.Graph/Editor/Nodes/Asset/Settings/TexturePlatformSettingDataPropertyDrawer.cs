using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DotEditor.Graph.Assets
{
    public abstract class TexturePlatformSettingDataPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var maxSizeProperty = property.FindPropertyRelative(nameof(TexturePlatformSettingData.maxSize));
            var algorithmProperty = property.FindPropertyRelative(nameof(TexturePlatformSettingData.resizeAlgorithm));
            var formatProperty = property.FindPropertyRelative(nameof(TexturePlatformSettingData.format));

            var container = new VisualElement();

            PopupField<int> maxSizeField = new PopupField<int>(maxSizeProperty.name);
            maxSizeField.choices = GenMaxSizeChoices();
            maxSizeField.value = maxSizeProperty.intValue;
            maxSizeField.RegisterValueChangedCallback(evt =>
            {
                maxSizeProperty.intValue = evt.newValue;
            });
            container.Add(maxSizeField);

            var algorithmField = new PropertyField(algorithmProperty);
            container.Add(algorithmField);

            var formatField = new PopupField<int>(formatProperty.name);
            formatField.choices = GenFormatChoices();
            formatField.value = formatProperty.intValue;
            formatField.formatSelectedValueCallback = v =>
            {
                return ((TextureImporterFormat)v).ToString();
            };
            formatField.formatListItemCallback = v =>
            {
                return ((TextureImporterFormat)v).ToString();
            };
            formatField.RegisterValueChangedCallback(evt =>
            {
                formatProperty.intValue = evt.newValue;
            });
            container.Add(formatField);

            return container;
        }

        protected virtual List<int> GenMaxSizeChoices()
        {
            return new List<int>()
            {
                32,64,128,256,512,1024,2048,4096,
            };
        }

        protected abstract List<int> GenFormatChoices();
    }

    [CustomPropertyDrawer(typeof(DefaultTexturePlatformSettingData))]
    public class DefaultTexturePlatformSettingDataPropertyDrawer : TexturePlatformSettingDataPropertyDrawer
    {
        protected override List<int> GenFormatChoices()
        {
            return new List<int>
            {
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.RGBA32,
            };
        }
    }

    [CustomPropertyDrawer(typeof(StandaloneTexturePlatformSettingData))]
    public class StandaloneTexturePlatformSettingDataPropertyDrawer : TexturePlatformSettingDataPropertyDrawer
    {
        protected override List<int> GenFormatChoices()
        {
            return new List<int>
            {
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.RGBA32,
            };
        }
    }

    [CustomPropertyDrawer(typeof(AndroidTexturePlatformSettingData))]
    public class AndroidTexturePlatformSettingDataPropertyDrawer : TexturePlatformSettingDataPropertyDrawer
    {
        protected override List<int> GenFormatChoices()
        {
            return new List<int>
            {
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.RGBA32,
            };
        }
    }

    [CustomPropertyDrawer(typeof(IOSTexturePlatformSettingData))]
    public class IOSTexturePlatformSettingDataPropertyDrawer : TexturePlatformSettingDataPropertyDrawer
    {
        protected override List<int> GenFormatChoices()
        {
            return new List<int>
            {
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.RGBA32,
                (int)TextureImporterFormat.ASTC_4x4,
                (int)TextureImporterFormat.ASTC_5x5,
                (int)TextureImporterFormat.ASTC_6x6,
                (int)TextureImporterFormat.ASTC_8x8,
                (int)TextureImporterFormat.ASTC_10x10,
                (int)TextureImporterFormat.ASTC_12x12,
                (int)TextureImporterFormat.ETC2_RGB4,
                (int)TextureImporterFormat.ETC2_RGBA8,

            };
        }
    }
}
