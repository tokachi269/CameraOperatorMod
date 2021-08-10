using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class SliderProperty : EditorPropertyItem
    {
        //TODO 各UIComponentをEditorItemを継承したものに変更する
        public FieldType TextField { get; set; }
        public UISlider Slider { get; set; }
        public UISlicedSprite Thumb { get; set; }
        public bool HasField = true;
        public bool hasButton = true;

        public int ItemsPadding = 10;

        public  SliderProperty()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = true;

            TextField = AddUIComponent<FieldType>();
            InitTextField();

            Slider = AddUIComponent<UISlider>();
            Thumb = Slider.AddUIComponent<UISlicedSprite>();
            InitSlider();
        }

        private void InitTextField()
        {
            TextField.relativePosition = new Vector2(0, (DefaultHeight - TextField.height) / 2);

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
            Slider.color = Helper.RGB(40, 40, 40);
            Slider.size = new Vector2(345, 6);
            Slider.relativePosition = new Vector2(0, DefaultHeight / 2);

            Thumb.atlas = base.atlas;
            Thumb.spriteName = "SliderBudget";
            Thumb.size = new Vector2(14f, 18f);
            Thumb.relativePosition = new Vector2(0f, 8f);

            Slider.thumbObject = Thumb;

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
