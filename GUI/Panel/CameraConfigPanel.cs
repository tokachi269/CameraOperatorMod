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

            FovSlider = AddUIComponent<SliderProperty>();
            FovSlider.autoLayout = true;

            ZoomSlider = AddUIComponent<SliderProperty>();
            ZoomSlider.autoLayout = true;

        }
    }
}