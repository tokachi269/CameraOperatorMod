using CameraOperatorMod.GUI;
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
            page.padding = Helper.Padding(6, 2);
            page.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 8, 0));
            page.autoFitChildrenVertically = true;
            page.backgroundSprite = "MenuPanelInfo";
            pane.color = Helper.RGB(10, 10, 10);
            {
                var pane = page.AddUIComponent<UIPanel>();
                pane.width = pane.parent.width - page.padding.horizontal;
                // pane.padding = Helper.Padding(4, 12, 4, 0);
                // pane.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
                pane.autoFitChildrenVertically = true;


                Helper.AddLabel(
                    ref pane,
                    "FOV",
                    color: Helper.RGB(240, 240, 250)
                );

                ToolHelper.AddConfig(
                     ref pane,
                     "Light intensity",
                     "default: ≈4.2",
                     opts: new SliderOption<float>(
                         minValue: 0.05f,
                         maxValue: 8.0f,
                         stepSize: 0.05f,
                         defaultValue: 0f,
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
