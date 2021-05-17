﻿using CameraOperatorMod.GUI;
using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using ForestBrush.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TokachiCinematicCameraMod.GUI
{
    public static class Path
    {
        public static void Setup(ref UIPanel page)
        {
            page.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(56, 2, 2, 2));
            page.autoFitChildrenVertically = true;
            page.backgroundSprite = "MenuPanelInfo";
            page.color = Helper.RGB(10, 10, 10);
            page.tooltip = "Path Base Panel";
            {
                var pane = page.AddUIComponent<UIPanel>();
                pane.width = pane.parent.width - page.padding.horizontal;
                pane.padding = Helper.Padding(4, 12, 4, 0);
                pane.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
                pane.autoFitChildrenVertically = true;

                ToolHelper.AddConfig(
                     ref pane,
                     "FOV",
                     "default: 50",
                     opts: new SliderOption<float>(
                         minValue: 5.0f,
                         maxValue: 150.0f,
                         stepSize: 1.0f,
                         defaultValue: 50f,
                         (c, value) => {
                             Debug.Log("Slider Cahanged");
                         })
                     {
                     },
                     indentPadding: 12
                );

                ToolHelper.AddConfig(
                     ref pane,
                     "FOV",
                     "default: 50",
                     opts: new SliderOption<float>(
                         minValue: 5.0f,
                         maxValue: 150.0f,
                         stepSize: 1.0f,
                         defaultValue: 50f,
                         (c, value) => {
                             Debug.Log("Slider Cahanged");
                         })
                     {
                     },
                     indentPadding: 12
                );


                FastList<object> fastList= new FastList<object>();
                fastList.Add(new {name = "name"});
                UIFastList myFastList = UIFastList.Create<KnotItem>(page);
                myFastList.size = new Vector2(200f, 300f);
                myFastList.rowHeight = 40f;
            }
        }
    }
}
