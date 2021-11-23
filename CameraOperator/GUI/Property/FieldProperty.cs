using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CamOpr.GUI
{
    public class FieldProperty : EditorPropertyItem
    {
        public FieldType Content { get; set; }
        public float DefaultHeight => 20f;

        public event Action<ValueType> OnValueChanged;

        public FieldProperty()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, base.DefaultHeight);

            autoLayout = false;

            Content = AddUIComponent<FieldType>();
        }

        protected override void InitPanel()
        {
            //Field.SetDefaultStyle();
            Content.name = nameof(Content);
            Content.scaleFactor = 0.7f;
            Content.cursorBlinkTime = 1f;
            Content.cursorWidth = 2;
            //Field.OnValueChanged += ValueChanged;
            Content.readOnly = false;
            Content.numericalOnly = true;
            Content.allowFloats = true;
            Content.builtinKeyNavigation = true;
            Content.canFocus = true;
            Content.selectOnFocus = true;
            Content.submitOnFocusLost = true;
            Content.selectionSprite = "EmptySprite";
            Content.normalBgSprite = "TextFieldPanel";
            Content.focusedBgSprite = "TextFieldPanel";
            Content.clipChildren = true;
            Content.colorizeSprites = true;
            Content.color = Helper.GrayScale(70);
            Content.textColor = Helper.GrayScale(250);
            Content.horizontalAlignment = UIHorizontalAlignment.Left;
            Content.padding = Helper.Padding(0, 6);
            Content.relativePosition = new Vector2(0f, DefaultHeight / 2);
            Content.size = new Vector2(50, 22);
        }

        protected override void OnSizeChanged()
        {
            SetSize();
            Refresh(false);
        }

        public override void Init()
        {
            base.Init();
            SetSize();
        }

        protected virtual void SetSize(float? width = null, float? height = null)
        {
            if (!(Content is null))
            {
                if (!(width is null)) base.width = Content.width;
                //if (!(height is null)) Field.height = (float)height;

                base.size = Content.size;
            }
            base.OnSizeChanged();
        }

        protected void Refresh(bool refreshContent = true)
        {
            if (!(Content is null))
            {
                Content.height = height;
              // Content.relativePosition = new Vector2(width - Content.width - ItemsPadding, 0f);
            }
        }

        private void SetLabel()
        {
            Label.width = width - Content.width - ItemsPadding * 2;
            Label.MakePixelPerfect(false);
            Label.relativePosition = new Vector2(5, (height - Label.height) / 2);
        }


    }
}
