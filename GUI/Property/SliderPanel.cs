using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class SliderPanel : EditorPropertyItem
    {
        public FieldType TextField { get; set; }
        public SliderProperty FieldSlider { get; set; }

        public bool HasField = true;
        public bool hasButton = true;
        public int ItemsPadding = 8;

        public override bool SupportAlignment => false;

        public SliderPanel()
        {
            TextField = Content.AddUIComponent<FieldType>();
            FieldSlider = Content.AddUIComponent<SliderProperty>();
            InitPanel();
        }

        protected override void InitPanel()
        {
            autoLayoutStart = LayoutStart.BottomLeft;

            autoLayoutDirection = LayoutDirection.Horizontal;

            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            autoLayoutPadding = Helper.Padding(0, ItemsPadding, 0, 0);
            padding = Helper.Padding(0, 0, 0, 4);

            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = true;

            //TextField.Init();
            InitTextField();

            FieldSlider.Slider.eventValueChanged += (c, value) => {
                if (TextField != null)
                {
                    TextField.text = value.ToString();
                }
            };
        }

        private void InitTextField()
        {
            //TextField.relativePosition = new Vector2(0,(DefaultHeight - TextField.height) / 2);

            TextField.width = 57;
            TextField.horizontalAlignment = UIHorizontalAlignment.Right;
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

        public override void UpdateValues<T>(T value)
        {
            FieldSlider.UpdateValues(value);
        }

        public class SliderProperty : EditorPropertyItem
        {
            public UISlider Slider { get; set; }
            public UISlicedSprite Thumb { get; set; }
            private float SliderWidth { get; set; }

            SliderProperty()
            {
                size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);

                Slider = Content.AddUIComponent<UISlider>();
                Thumb = Slider.AddUIComponent<UISlicedSprite>();
                InitPanel();
            }

            protected override void InitPanel()
            {
                Slider.scrollWheelAmount = (Slider.stepSize * 2) + 1.192093E-07f;
                Slider.backgroundSprite = "WhiteRect";
                Slider.color = Helper.RGB(40, 40, 40);
                Slider.size = new Vector2(345f, 6f);
                Slider.relativePosition = new Vector2(0f, DefaultHeight / 2);

                Thumb.atlas = base.atlas;
                Thumb.spriteName = "SliderBudget";
                Thumb.size = new Vector2(14f, 18f);
                Thumb.relativePosition = new Vector2(0f,(DefaultHeight / 2) + 8f);

                Alignment.width = 345f;

                Slider.thumbObject = Thumb;

                autoLayout = true;

            }

            public override void UpdateValues<T>(T value)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
