using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using System;
using TokachiCinematicCameraMod.GUI.Property;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
        private FieldProperty field;
        private UISlider FOVSlider;
        private UITextField TextField;
        private UILabel label;
        public CameraConfigPanel()
        {
            field = AddUIComponent<FieldProperty>();
            size = new Vector2(CameraOperator.DefaultRect.width, 200);
            padding = Helper.Padding(4, 12, 4, 0);
            autoFitChildrenVertically = true;
            clipChildren = false;

            TextField = AddUIComponent<UITextField>();
            TextField.readOnly = false;
            TextField.numericalOnly = true;
            TextField.allowFloats = true;
            TextField.builtinKeyNavigation = true;
            TextField.canFocus = true;
            TextField.selectOnFocus = true;
            TextField.submitOnFocusLost = true;
            TextField.cursorBlinkTime = 0.5f;
            TextField.cursorWidth = 1;
            TextField.selectionSprite = "EmptySprite";
            TextField.normalBgSprite = "TextFieldPanel";
            TextField.focusedBgSprite = "TextFieldPanel";
            TextField.clipChildren = true;
            TextField.colorizeSprites = true;
            TextField.color = Helper.RGB(30, 30, 30);
            TextField.textColor = Helper.RGB(250, 250, 250);
            TextField.horizontalAlignment = UIHorizontalAlignment.Left;
            TextField.padding = Helper.Padding(0, 6);
            TextField.eventTextSubmitted += (c, text) => {
                if (text == "") return;
                try
                {
                    FOVSlider.value = float.Parse(text);

                }
                catch (Exception e)
                {
                    //Log.Error($"failed to set new value \"{text}\": {e}");
                    TextField.text = "";
                }
            };

            FOVSlider = AddUIComponent<UISlider>();
            FOVSlider.minValue = 1.0f;
            FOVSlider.maxValue = 150.0f;
            FOVSlider.stepSize = 0.1f;
            FOVSlider.value = 60f;
            FOVSlider.scrollWheelAmount = (FOVSlider.stepSize * 2) + 1.192093E-07f;
            FOVSlider.eventValueChanged += (c, value) => {
                if (TextField != null)
                {
                    TextField.text = value.ToString();
                }
            };
        }
    }
}