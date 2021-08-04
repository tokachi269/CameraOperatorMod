using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class SliderProperty : EditorPropertyItem
    {
        public FieldProperty Field;
        public UISlider FOVSlider;
        public UITextField TextField;

        public bool hasField = true;
        public bool hasButton = true;
        public int ItemsPadding = 14;
        public SliderProperty(): base()
        {
            Field = AddUIComponent<FieldProperty>();
            Field.Init();
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;

            TextField = AddUIComponent<UITextField>();
            TextField.readOnly = false;
            TextField.numericalOnly = true;
            TextField.allowFloats = true;
            TextField.builtinKeyNavigation = true;
            TextField.canFocus = true;
            TextField.selectOnFocus = true;
            TextField.submitOnFocusLost = true;
            TextField.cursorBlinkTime = 1f;
            TextField.cursorWidth = 2;
            TextField.selectionSprite = "EmptySprite";
            TextField.normalBgSprite = "TextFieldPanel";
            TextField.focusedBgSprite = "TextFieldPanel";
            TextField.clipChildren = true;
            TextField.colorizeSprites = true;
            TextField.color = Helper.RGB(50, 50, 50);
            TextField.textColor = Helper.RGB(250, 250, 250);
            TextField.horizontalAlignment = UIHorizontalAlignment.Left;
            TextField.size = new Vector2(50, 22);
            TextField.padding = Helper.Padding(0, 6);
            TextField.relativePosition = new Vector2(0, 0);
            //TextField.eventTextSubmitted += (c, text) => {
            //    if (text == "") return;
            //    try
            //    {
            //        FOVSlider.value = float.Parse(text);
            //
            //    }
            //    catch (Exception e)
            //    {
            //        //Log.Error($"failed to set new value \"{text}\": {e}");
            //        TextField.text = "";
            //    }
            //};

            FOVSlider = AddUIComponent<UISlider>();
            FOVSlider.minValue = 1.0f;
            FOVSlider.maxValue = 150.0f;
            FOVSlider.stepSize = 0.1f;
            FOVSlider.value = 60f;
            FOVSlider.scrollWheelAmount = (FOVSlider.stepSize * 2) + 1.192093E-07f;
            FOVSlider.backgroundSprite = "WhiteRect";
            FOVSlider.color = Helper.RGB(136, 136, 136);
            FOVSlider.size = new Vector2(345, 6);
            FOVSlider.relativePosition = new Vector2(0, DefaultHeight / 2);

            FOVSlider.eventValueChanged += (c, value) => {
                if (TextField != null)
                {
                    TextField.text = value.ToString();
                }
            };
        }
    }
    public class SliderPane
    {
        public UIPanel wrapper;
        public UISlider slider;
        public UITextField field;
    }
}
