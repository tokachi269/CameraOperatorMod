using System;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel : UIPanel
    {
        private int DefaultHeight = 160;
        public SliderPanel FovSlider;
        public SliderPanel ZoomSlider;

        public ButtonPanel AddButton;
        public float aspect = 2.34f;

        public CameraConfigPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            clipChildren = false;

            FovSlider = AddUIComponent<SliderPanel>();
            FovSlider.name = nameof(FovSlider);
            FovSlider.Init(minValue: 1f, maxValue: 179f, stepSize: 0.1f, defaultValue: 60f);
            FovSlider.FieldSlider.Slider.eventValueChanged += delegate(UIComponent c, float p)
            {
                CameraOperatorMod.CameraOperator.mainCamera.fieldOfView = p / 2f;
            };

            ZoomSlider = AddUIComponent<SliderPanel>();
            ZoomSlider.name = nameof(ZoomSlider);
            ZoomSlider.Init(minValue: 1f, maxValue: 179f, stepSize: 0.0001f, defaultValue: 1f);
            ZoomSlider.FieldSlider.Slider.eventValueChanged += delegate (UIComponent c, float p)
            {
                CameraOperatorMod.CameraOperator.mainCamera.fieldOfView = p / 2f;
                CameraOperatorMod.CameraOperator.cameraController.m_currentSize =
                    (float)(CameraOperatorMod.CameraOperator.mainCamera.fieldOfView * aspect);
                //CameraManeger.cameraController.m_targetSize =
                //    (float)(36 / Math.Tan(CameraManeger.mainCamera.fieldOfView / 2) * 2);
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