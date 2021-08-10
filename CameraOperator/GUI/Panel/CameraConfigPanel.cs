using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
        int DefaultHeight = 160;
        public SliderProperty FovSlider;
        public SliderProperty ZoomSlider;


        public CameraConfigPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            clipChildren = false;
            // autoFitChildrenVertically = true; //いらない
            autoLayout = false;

            FovSlider = AddUIComponent<SliderProperty>();
            FovSlider.Init(minValue: 1f, maxValue: 150f, stepSize: 0.1f, defaultValue: 60f);

            ZoomSlider = AddUIComponent<SliderProperty>();
            ZoomSlider.Init(minValue: 1f, maxValue: 150f, stepSize: 0.1f, defaultValue: 60f);

            autoLayoutDirection = LayoutDirection.Vertical;
            autoLayout = true;
        }
    }
}