using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CamOpr.GUI
{
    public class ButtonProperty : EditorPropertyItem
    {
        public ButtonType Button { get; set; }

        public override int ItemsPadding => 4;
        public override float DefaultHeight => 28;
        public override bool HasLabel => false;

        public event Action OnButtonClick;
        public void ButtonClick(UIComponent component, UIMouseEventParameter eventParam) => OnButtonClick?.Invoke();

        public ButtonProperty()
        {
            Button = Content.AddUIComponent<ButtonType>();
            InitPanel();
            Button.eventClick += ButtonClick;
        }

        protected override void InitPanel()
        {
            Button.size = size = CameraOperator.DefaultFormSize;
            autoLayoutDirection = LayoutDirection.Horizontal;
            clipChildren = false;
            autoLayoutPadding = Helper.Padding(0, ItemsPadding, 0, ItemsPadding);

            autoLayout = true;
            if (HasLabel) {
                Label.width = base.width - Content.width;
            }
        }

        public override void Init()
        {
            base.Init();
            SetSize();
        }

        protected virtual void SetSize(float? width = null, float? height = null)
        {
            if (!(Button is null))
            {
                if (!(width is null)) base.width = Button.width;
                //if (!(height is null)) Field.height = (float)height;

                base.size = Button.size;
            }
            base.OnSizeChanged();
        }

        protected void Refresh(bool refreshContent = true)
        {
            if (!(Button is null))
            {
                Button.height = height;
                // Content.relativePosition = new Vector2(width - Content.width - ItemsPadding, 0f);
            }
        }

        private void SetLabel()
        {
            Label.width = width - Button.width - ItemsPadding * 2;
            Label.MakePixelPerfect(false);
            // Label.relativePosition = new Vector2(5, (height - Label.height) / 2);
        }

        public override void UpdateValues<T>(T value)
        {
            Button.text = value.ToString();
        }
    }
}
