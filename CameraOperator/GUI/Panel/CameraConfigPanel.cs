using System;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class CameraConfigPanel : UIPanel
    {
        private int DefaultHeight = 160;
        public SliderPanel FovSlider;
        public SliderPanel ZoomSlider;

        public ButtonPanel AddButton;
        public float aspect = 1f; //2.34f;

        public void Awake()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            clipChildren = false;

            FovSlider = AddUIComponent<SliderPanel>();
            FovSlider.name = nameof(FovSlider);
            FovSlider.Init(minValue: 1f, maxValue: 179f, stepSize: 0.1f, defaultValue: 60f);
            FovSlider.FieldSlider.Slider.eventValueChanged += delegate(UIComponent c, float p)
            {
                CamOpr.CameraOperator.MainCamera.fieldOfView = p / 2f;
            };

            ZoomSlider = AddUIComponent<SliderPanel>();
            ZoomSlider.name = nameof(ZoomSlider);
            ZoomSlider.Init(minValue: 10f, maxValue: 1000f, stepSize: 0.0001f, defaultValue: 1f);
            ZoomSlider.FieldSlider.Slider.eventValueChanged += delegate (UIComponent c, float p)
            {

                /*
                 * イメージセンサーサイズ参考
                 * フルサイズ ：(水平*垂直)  36mm *   24mm
                 * APS-C      ：(水平*垂直)22.3mm * 14.9mm
                 */
                Debug.Log((float)(Math.Atan(36 / (2 * p)) * Mathf.Rad2Deg));
                CamOpr.CameraOperator.MainCamera.fieldOfView = (float)(Math.Atan(36 / (2 * p)) * Mathf.Rad2Deg);
                CamOpr.CameraOperator.CameraController.m_currentSize =
                    (float)(CamOpr.CameraOperator.MainCamera.fieldOfView * aspect);
                CamOpr.CameraOperator.CameraController.m_targetSize =
                    (float)(CamOpr.CameraOperator.MainCamera.fieldOfView * aspect);

            };
            autoLayoutDirection = LayoutDirection.Vertical;

            autoLayout = true;
            autoLayout = false;

            AddButton = AddUIComponent<ButtonPanel>();
            AddButton.name = nameof(AddButton);
            AddButton.Init(40f, 40f, "+", 2f);
            AddButton.relativePosition = new Vector2(425f, 0f);

        }
    }
}