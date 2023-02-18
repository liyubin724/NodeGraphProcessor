using GraphProcessor;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

[NodeCustomEditor(typeof(TextureImporterPlatformSettingNode))]
public class TextureImporterPlatformSettingNodeView : BaseNodeView
{
    private static List<int> sm_MaxSizeChoices = new List<int>()
    {
        64,128,256,512,1024,2048,4096
    };

    private static List<int> sm_StandaloneFormatValues = new List<int>
        {
            (int)TextureImporterFormat.DXT5,
            (int)TextureImporterFormat.RGBA16,
            (int)TextureImporterFormat.RGBA32,
        };

    private static List<int> sm_AndroidFormatValues = new List<int>
        {
            (int)TextureImporterFormat.ETC2_RGBA8,
            (int)TextureImporterFormat.ETC2_RGBA8Crunched,
            (int)TextureImporterFormat.RGBA16,
            (int)TextureImporterFormat.RGBA32,
        };

    private static List<int> sm_IPhoneFormatValues = new List<int>
        {
            (int)TextureImporterFormat.ASTC_4x4,
            (int)TextureImporterFormat.ASTC_8x8,
            (int)TextureImporterFormat.RGBA16,
            (int)TextureImporterFormat.RGBA32,
        };
    private static Dictionary<ETargetPlatform, List<int>> sm_PlatformFormatValueDic = new Dictionary<ETargetPlatform, List<int>>()
    {
        { ETargetPlatform.Standalone,sm_StandaloneFormatValues },
        {ETargetPlatform.Android,sm_AndroidFormatValues },
        {ETargetPlatform.iPhone,sm_IPhoneFormatValues },
    };

    private TextureImporterPlatformSettingNode m_SettingNode;
    private PopupField<int> m_FormatField;

    public override void Enable()
    {
        m_SettingNode = nodeTarget as TextureImporterPlatformSettingNode;

        InitPlatform();
        InitMaxSizeField();
        UpdateTextureFormat();
    }

    private void InitMaxSizeField()
    {
        var indexOf = sm_MaxSizeChoices.IndexOf(m_SettingNode.maxSize);
        if (indexOf < 0)
        {
            indexOf = 0;
            m_SettingNode.maxSize = sm_MaxSizeChoices[indexOf];
        }

        var maxSizePopup = new PopupField<int>("Max Size", sm_MaxSizeChoices, indexOf);
        maxSizePopup.formatListItemCallback = (size) =>
        {
            return $"{size} X {size}";
        };
        maxSizePopup.RegisterValueChangedCallback((evt) =>
        {
            owner.RegisterCompleteObjectUndo("Editor max size");
            m_SettingNode.maxSize = evt.newValue;
        });

        controlsContainer.Add(maxSizePopup);
    }

    private void InitPlatform()
    {
        var platformField = new EnumField("Platform", m_SettingNode.platform);
        platformField.RegisterValueChangedCallback((evt) =>
        {
            owner.RegisterCompleteObjectUndo("Editor texture setting platform");
            m_SettingNode.platform = (ETargetPlatform)evt.newValue;
            UpdateTextureFormat();
        });
        controlsContainer.Add(platformField);
    }

    private void UpdateTextureFormat()
    {
        if (m_FormatField != null)
        {
            m_FormatField.RemoveFromHierarchy();
            m_FormatField = null;
        }

        List<int> values = sm_PlatformFormatValueDic[m_SettingNode.platform];

        int indexOf = values.IndexOf((int)m_SettingNode.format);
        if (indexOf < 0)
        {
            m_SettingNode.format = TextureImporterFormat.RGBA32;
            indexOf = values.IndexOf((int)m_SettingNode.format);
        }
        m_FormatField = new PopupField<int>("Format", values, indexOf);
        m_FormatField.RegisterValueChangedCallback(evt =>
        {
            owner.RegisterCompleteObjectUndo("Editor texture setting platform");
            m_SettingNode.format = (TextureImporterFormat)evt.newValue;
        });
        m_FormatField.formatListItemCallback = (value) =>
        {
            return ((TextureImporterFormat)value).ToString();
        };
        m_FormatField.formatSelectedValueCallback = (value) =>
        {
            return ((TextureImporterFormat)value).ToString();
        };
        controlsContainer.Add(m_FormatField);
    }
}
