using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class FieldProperty : EditorPropertyItem
    {
        public FieldType Field { get; set; }
        public float Height => 20f;

        public event Action<ValueType> OnValueChanged;

        public FieldProperty()
        {
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
            Field.size = new Vector2(50, 22);
            Field.padding = Helper.Padding(0, 6);
            Field.relativePosition = new Vector2(0, 0);
        }

        public override void Init()
        {
            base.Init();
            SetSize();
        }

        protected virtual void SetSize()
        {
            Field.size = new Vector2(width - ItemsPadding * 2, Height);
            Field.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);
        }
    }
}
