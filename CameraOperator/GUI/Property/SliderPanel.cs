﻿using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class SliderPanel : EditorPropertyItem
    {
        //TODO 各UIComponentをEditorItemを継承したものに変更する
        public FieldProperty TextField { get; set; }
        public SliderProperty FieldSlider { get; set; }

        public bool HasField = true;
        public bool hasButton = true;

        public int ItemsPadding = 10;
        public override bool SupportAlignment => false;
        public  SliderPanel()
        {
            autoLayoutDirection = LayoutDirection.Horizontal;

            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = true;

            TextField = AddUIComponent<FieldProperty>();
            InitTextField();

            FieldSlider = AddUIComponent<SliderProperty>();
            FieldSlider.InitSlider();
            FieldSlider.Slider.eventValueChanged += (c, value) => {
                if (TextField != null)
                {
                    TextField.Field.text = value.ToString();
                }
            };

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

        public void Init(float minValue, float maxValue, float stepSize, float defaultValue)
        {
            FieldSlider.Slider.minValue = minValue;
            FieldSlider.Slider.maxValue = maxValue;
            FieldSlider.Slider.stepSize = stepSize;
            FieldSlider.Slider.value = defaultValue;
        }

        public class SliderProperty : EditorPropertyItem
        {
            public UISlider Slider { get; set; }
            public UISlicedSprite Thumb { get; set; }
            SliderProperty()
            {
                size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);

                Slider = AddUIComponent<UISlider>();
                Thumb = Slider.AddUIComponent<UISlicedSprite>();
                InitSlider();
            }
            public void InitSlider()
            {
                Slider.scrollWheelAmount = (Slider.stepSize * 2) + 1.192093E-07f;
                Slider.backgroundSprite = "WhiteRect";
                Slider.color = Helper.RGB(40, 40, 40);
                Slider.size = new Vector2(345f, 6f);
                Slider.relativePosition = new Vector2(0, DefaultHeight / 2);

                Thumb.atlas = base.atlas;
                Thumb.spriteName = "SliderBudget";
                Thumb.size = new Vector2(14f, 18f);
                Thumb.relativePosition = new Vector2(0f, 8f);

                Slider.thumbObject = Thumb;
            }
            protected override void OnSizeChanged()
            {
                base.OnSizeChanged();
                SetSize();
            }
            public override void Init()
            {
                base.Init();
                SetSize();
            }

            protected virtual void SetSize(float? width = null, float? height = null)
            {
                if (!(Slider is null))
                {
                    if (!(width is null)) base.width = Slider.width;
                    //if (!(height is null)) Slider.height = (float)height;

                    base.size = Slider.size;
                }
                base.OnSizeChanged();

            }
        }
    }
    public class SliderPane
    {
        public UIPanel wrapper;
        public UISlider slider;
        public UITextField field;

    }
}
