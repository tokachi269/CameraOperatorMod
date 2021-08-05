using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class SliderProperty : EditorPropertyItem
    {
        public FieldType TextField { get; set; }
        public UISlider Slider { get; set; }

        public bool hasField = true;
        public bool hasButton = true;
        public int ItemsPadding = 14;

        public SliderProperty() : base()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = false;
            TextField = AddUIComponent<FieldType>();
            InitTextField();
            Slider = AddUIComponent<UISlider>();

            InitTextField();
            InitSlider();
        }

        private void InitTextField()
        {
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

        }
        private void InitSlider()
        {
            Slider.scrollWheelAmount = (Slider.stepSize * 2) + 1.192093E-07f;
            Slider.backgroundSprite = "WhiteRect";
            Slider.color = Helper.RGB(136, 136, 136);
            Slider.size = new Vector2(345, 6);
            Slider.relativePosition = new Vector2(0, DefaultHeight / 2);

            Slider.eventValueChanged += (c, value) => {
                if (TextField != null)
                {
                    TextField.text = value.ToString();
                }
            };
        }

        public void Init(float minValue, float maxValue, float stepSize, float defaultValue)
        {
            Slider.minValue = minValue;
            Slider.maxValue = maxValue;
            Slider.stepSize = stepSize;
            Slider.value = defaultValue;
        }
    }
    public class SliderPane
    {
        public UIPanel wrapper;
        public UISlider slider;
        public UITextField field;
    }
}
