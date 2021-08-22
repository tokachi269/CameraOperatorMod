using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class FieldProperty : EditorPropertyItem
    {
        public FieldType Field { get; set; }
        public float DefaultHeight => 20f;

        public event Action<ValueType> OnValueChanged;

        public FieldProperty()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, base.DefaultHeight);

            autoLayout = false;

            Field = AddUIComponent<FieldType>();
            //Field.SetDefaultStyle();
            Field.name = nameof(Field);
            Field.cursorBlinkTime = 1f;
            Field.cursorWidth = 2;
            //Field.OnValueChanged += ValueChanged;
            Field.readOnly = false;
            Field.numericalOnly = true;
            Field.allowFloats = true;
            Field.builtinKeyNavigation = true;
            Field.canFocus = true;
            Field.selectOnFocus = true;
            Field.submitOnFocusLost = true;
            Field.selectionSprite = "EmptySprite";
            Field.normalBgSprite = "TextFieldPanel";
            Field.focusedBgSprite = "TextFieldPanel";
            Field.clipChildren = true;
            Field.colorizeSprites = true;
            Field.color = Helper.RGB(50, 50, 50);
            Field.textColor = Helper.RGB(250, 250, 250);
            Field.horizontalAlignment = UIHorizontalAlignment.Left;
            Field.padding = Helper.Padding(0, 6);
            Field.relativePosition = new Vector2(0, 0);
            Field.size = new Vector2(50, 22);
        }
        protected override void OnSizeChanged()
        {
            SetSize();
        }
        public override void Init()
        {
            base.Init();
            SetSize();
        }

        protected virtual void SetSize(float? width = null, float? height = null)
        {
            if (!(Field is null))
            {
                if (!(width is null)) base.width = Field.width;
                //if (!(height is null)) Field.height = (float)height;

                base.size = Field.size;
            }
            base.OnSizeChanged();

        }

    }
}
