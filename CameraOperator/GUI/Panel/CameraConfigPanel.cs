using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
        int DefaultHeight = 160;
        public SliderPanel FovSlider;
        public SliderPanel ZoomSlider;

        public ButtonPanel ButtonPanel;


        public CameraConfigPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            clipChildren = false;

            FovSlider = AddUIComponent<SliderPanel>();
            FovSlider.Init(minValue: 1f, maxValue: 150f, stepSize: 0.1f, defaultValue: 60f);

            ZoomSlider = AddUIComponent<SliderPanel>();
            ZoomSlider.Init(minValue: 1f, maxValue: 150f, stepSize: 0.1f, defaultValue: 60f);

            autoLayoutDirection = LayoutDirection.Vertical;

            autoLayout = true;
            autoLayout = false;

            ButtonPanel = AddUIComponent<ButtonPanel>();
           // ButtonPanel.Init();
        }
    }
}