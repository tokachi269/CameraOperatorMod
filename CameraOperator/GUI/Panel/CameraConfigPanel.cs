using System;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel : UIPanel
    {
        int DefaultHeight = 160;
        public SliderPanel FovSlider;
        public SliderPanel ZoomSlider;

        public ButtonPanel ButtonPanel;
        public float aspect = 2.34f;

        public CameraConfigPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            clipChildren = false;
            FovSlider = AddUIComponent<SliderPanel>();
            FovSlider.Init(minValue: 1f, maxValue: 179f, stepSize: 0.1f, defaultValue: 60f);
            FovSlider.FieldSlider.Slider.eventValueChanged += delegate(UIComponent c, float p)
            {
                CameraManeger.mainCamera.fieldOfView = p / 2f;
            };
            ZoomSlider = AddUIComponent<SliderPanel>();
            ZoomSlider.Init(minValue: 1f, maxValue: 179f, stepSize: 0.0001f, defaultValue: 1f);
            ZoomSlider.FieldSlider.Slider.eventValueChanged += delegate (UIComponent c, float p)
            {
                CameraManeger.mainCamera.fieldOfView = p / 2f;
                CameraManeger.cameraController.m_targetSize +=
                    (float)(CameraManeger.mainCamera.fieldOfView * aspect);
                //CameraManeger.cameraController.m_targetSize =
                //    (float)(36 / Math.Tan(CameraManeger.mainCamera.fieldOfView / 2) * 2);
            };
            autoLayoutDirection = LayoutDirection.Vertical;

            autoLayout = true;
            autoLayout = false;

            ButtonPanel = AddUIComponent<ButtonPanel>();
            ButtonPanel.Init(40f, 40f, "+", 2f);
            ButtonPanel.relativePosition = new Vector2(410f, 45f);

        }
    }
}