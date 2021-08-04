using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
        int DefaultHeight = 160;
        public SliderProperty SliderProperty;

        public CameraConfigPanel()
        {
            SliderProperty = AddUIComponent<SliderProperty>();
            SliderProperty.autoLayout = true;
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;


        }
    }
}