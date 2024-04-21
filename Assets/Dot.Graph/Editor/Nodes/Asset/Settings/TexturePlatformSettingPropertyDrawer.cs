using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DotEditor.Graph.Assets
{
    [CustomPropertyDrawer(typeof(TexturePlatformSetting))]
    public class TexturePlatformSettingPropertyDrawer : PropertyDrawer
    {
        private List<string> m_PlatformNames = new List<string>()
        {
            "Default","Standalone","Android","iPhone"
        };
        private Dictionary<string, List<int>> m_PlatformMaxSizeDic = new Dictionary<string, List<int>>()
        {
            {"Default",new List<int>(){ 32, 64, 128, 256, 512, 1024, 2048, 4096, } },
            {"Standalone",new List<int>(){ 32, 64, 128, 256, 512, 1024, 2048, 4096, } },
            {"Android",new List<int>(){ 32, 64, 128, 256, 512, 1024, 2048, 4096, } },
            {"iPhone",new List<int>(){ 32, 64, 128, 256, 512, 1024, 2048, 4096, } },
        };
        private Dictionary<string, List<int>> m_PlatformFormatDic = new Dictionary<string, List<int>>()
        {
            {"Default",new List<int>(){
                (int)TextureImporterFormat.RGBA32,
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
            } },
            {"Standalone",new List<int>(){
                (int)TextureImporterFormat.RGBA32,
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.DXT1,
                (int)TextureImporterFormat.DXT5,
            } },
            {"Android",new List<int>(){
                (int)TextureImporterFormat.RGBA32,
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.ASTC_4x4,
                (int)TextureImporterFormat.ASTC_5x5,
                (int)TextureImporterFormat.ASTC_6x6,
                (int)TextureImporterFormat.ASTC_8x8,
                (int)TextureImporterFormat.ASTC_10x10,
                (int)TextureImporterFormat.ASTC_12x12,
                (int)TextureImporterFormat.ETC2_RGB4,
                (int)TextureImporterFormat.ETC2_RGBA8,
            } },
            {"iPhone",new List<int>(){
                (int)TextureImporterFormat.RGBA32,
                (int)TextureImporterFormat.RGB24,
                (int)TextureImporterFormat.RGB16,
                (int)TextureImporterFormat.ASTC_4x4,
                (int)TextureImporterFormat.ASTC_5x5,
                (int)TextureImporterFormat.ASTC_6x6,
                (int)TextureImporterFormat.ASTC_8x8,
                (int)TextureImporterFormat.ASTC_10x10,
                (int)TextureImporterFormat.ASTC_12x12,
                (int)TextureImporterFormat.ETC2_RGB4,
                (int)TextureImporterFormat.ETC2_RGBA8,
                (int)TextureImporterFormat.PVRTC_RGB2,
                (int)TextureImporterFormat.PVRTC_RGB4,
                (int)TextureImporterFormat.PVRTC_RGBA2,
                (int)TextureImporterFormat.PVRTC_RGBA4,
            } },
        };

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var nameProperty = property.FindPropertyRelative(nameof(TexturePlatformSetting.name));
            var maxSizeProperty = property.FindPropertyRelative(nameof(TexturePlatformSetting.maxSize));
            var algorithmProperty = property.FindPropertyRelative(nameof(TexturePlatformSetting.resizeAlgorithm));
            var formatProperty = property.FindPropertyRelative(nameof(TexturePlatformSetting.format));

            var container = new VisualElement();

            var nameField = new PopupField<string>(nameProperty.name);
            nameField.choices = m_PlatformNames;
            nameField.value = nameProperty.stringValue;
            container.Add(nameField);

            PopupField<int> maxSizeField = new PopupField<int>(maxSizeProperty.name);
            maxSizeField.choices = m_PlatformMaxSizeDic[nameProperty.stringValue];
            maxSizeField.value = maxSizeProperty.intValue;
            container.Add(maxSizeField);

            var algorithmField = new PropertyField(algorithmProperty);
            container.Add(algorithmField);

            var formatField = new PopupField<int>(formatProperty.name);
            formatField.choices = m_PlatformFormatDic[nameProperty.stringValue];
            formatField.value = formatProperty.intValue;
            formatField.formatSelectedValueCallback = v =>
            {
                return ((TextureImporterFormat)v).ToString();
            };
            formatField.formatListItemCallback = v =>
            {
                return ((TextureImporterFormat)v).ToString();
            };
            container.Add(formatField);

            nameField.RegisterValueChangedCallback(evt =>
            {
                nameProperty.stringValue = evt.newValue;

                maxSizeField.choices = m_PlatformMaxSizeDic[nameProperty.stringValue];
                formatField.choices = m_PlatformFormatDic[nameProperty.stringValue];

                property.serializedObject.ApplyModifiedProperties();
            });

            maxSizeField.RegisterValueChangedCallback(evt =>
            {
                maxSizeProperty.intValue = evt.newValue;

                property.serializedObject.ApplyModifiedProperties();
            });

            formatField.RegisterValueChangedCallback(evt =>
            {
                formatProperty.intValue = evt.newValue;

                property.serializedObject.ApplyModifiedProperties();
            });

            return container;
        }
    }
}
