﻿using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
        private UISlider FOVSlider;
        public void Awake()
        {
            base.Awake();
            {

                size = new Vector2(CameraOperator.DefaultRect.width, 200);
                padding = Helper.Padding(4, 12, 4, 0);
                autoFitChildrenVertically = true;
                clipChildren = false;
                
                FOVSlider = AddUIComponent<UISlider>();
                FOVSlider.minValue = 1.0f;
                FOVSlider.maxValue = 150.0f;
                FOVSlider.stepSize = 0.1f;
                FOVSlider.value = 60f;
                FOVSlider = ToolHelper.AddConfig(
                     this,
                     "FOV",
                     "default: 60",
                     opts: new SliderOption<float>(
                         minValue: 1.0f,
                         maxValue: 150.0f,
                         stepSize: 0.1f,
                         defaultValue: 60f,
                         (c, value) => {
                             Debug.Log("Slider Cahanged");
                         })
                     {
                     },
                     labelPadding: 4,
                     indentPadding: 12
                );
            }
        }
    }
}