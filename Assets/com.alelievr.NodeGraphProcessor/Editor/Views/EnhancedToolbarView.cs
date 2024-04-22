using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    public class EnhancedToolbarView : Toolbar
    {
        public class UxmlTrais : VisualElement.UxmlTraits { }

        public new class UxmlFactory : UxmlFactory<EnhancedToolbarView, UxmlTraits> { }

        private VisualElement m_LeftContainer;
        private VisualElement m_RightContainer;

        public VisualElement leftContainer => m_LeftContainer;
        public VisualElement rightContainer => m_RightContainer;

        public override VisualElement contentContainer => m_LeftContainer;

        public EnhancedToolbarView() : base()
        {
            m_LeftContainer = new VisualElement();
            m_LeftContainer.name = "left-container";
            m_LeftContainer.style.flexDirection = FlexDirection.Row;
            hierarchy.Add(m_LeftContainer);

            var space = new VisualElement();
            space.pickingMode = PickingMode.Ignore;
            space.style.flexGrow = 1;
            hierarchy.Add(space);

            m_RightContainer = new VisualElement();
            m_RightContainer.name = "right-container";
            m_RightContainer.style.flexDirection = FlexDirection.Row;
            hierarchy.Add(m_RightContainer);
        }

        public ToolbarButton AddLeftButton(string text, Action click)
        {
            var toolbarBtn = new ToolbarButton(click) { text = text };
            toolbarBtn.style.position = Position.Relative;
            m_LeftContainer.Add(toolbarBtn);

            return toolbarBtn;
        }

        public void AddLeftSpace(int width = 6)
        {
            var toolbarSpace = new ToolbarSpacer();
            toolbarSpace.style.width = width;
            m_LeftContainer.Add(toolbarSpace);
        }

        public ToolbarToggle AddLeftToggle(string text, bool value, Action<bool> onChanged)
        {
            var toolbarToggle = new ToolbarToggle()
            {
                text = text,
                value = value,
            };
            toolbarToggle.style.position = Position.Relative;
            toolbarToggle.RegisterValueChangedCallback((evt) =>
            {
                onChanged?.Invoke(evt.newValue);
            });
            m_LeftContainer.Add(toolbarToggle);

            return toolbarToggle;
        }

        public Label AddLeftLabel(string text)
        {
            var label = new Label();
            label.text = text;
            m_LeftContainer.Add(label);

            return label;
        }

        public void AddLeftElement(VisualElement element)
        {
            m_LeftContainer.Add(element);
        }

        public ToolbarButton AddRightButton(string text, Action onClick)
        {
            var toolbarBtn = new ToolbarButton(onClick) { text = text };
            toolbarBtn.style.position = Position.Relative;
            m_RightContainer.Add(toolbarBtn);

            return toolbarBtn;
        }

        public void AddRightSpace(int width = 6)
        {
            var toolbarSpace = new ToolbarSpacer();
            toolbarSpace.style.width = width;
            m_RightContainer.Add(toolbarSpace);
        }

        public ToolbarToggle AddRightToggle(string text, bool value, Action<bool> onChanged)
        {
            var toolbarToggle = new ToolbarToggle()
            {
                text = text,
                value = value,
            };
            toolbarToggle.style.position = Position.Relative;
            toolbarToggle.RegisterValueChangedCallback((evt) =>
            {
                onChanged?.Invoke(evt.newValue);
            });
            m_RightContainer.Add(toolbarToggle);

            return toolbarToggle;
        }

        public Label AddRightLabel(string text)
        {
            var label = new Label();
            label.text = text;
            m_RightContainer.Add(label);

            return label;
        }

        public void AddRightElement(VisualElement element)
        {
            m_RightContainer.Add(element);
        }

        public void RemoveAllElements()
        {
            m_LeftContainer.Clear();
            m_RightContainer.Clear();
        }
    }
}
