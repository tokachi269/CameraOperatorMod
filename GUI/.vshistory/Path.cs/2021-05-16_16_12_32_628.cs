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

            {
                var pane = page.AddUIComponent<UIPanel>();
                pane.width = pane.parent.width - page.padding.horizontal;
                //pane.padding = Helper.Padding(4, 12, 4, 0);
                // pane.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
                pane.autoFitChildrenVertically = true;

                Helper.AddLabel(
                    ref pane,
                    "Light & Shadow",
                    color: Helper.RGB(220, 230, 250),
                    bullet: "LineDetailButton"
                );

                ToolHelper.AddConfig(
                     ref pane,
                     "Light intensity",
                     "default: ≈4.2",
                     opts: new SliderOption<float>(
                         minValue: 0.05f,
                         maxValue: 8.0f,
                         stepSize: 0.05f,
                         initialValue: 0f,
                         (c, value) => {
                             Debug.Log("Slider Cahanged");
                         })
                     {
                         isEnabled = App.Config.Graphics.lightIntensity.Enabled,
                         onSwitched = App.Config.Graphics.lightIntensity.LockedSwitch(App.Config.GraphicsLock),
                     },
                     indentPadding: 12
                );

                UIFastList myFastList = UIFastList.Create<KnotItem>(page);
                myFastList.size = new Vector2(200f, 300f);
                myFastList.rowHeight = 40f;

                //myFastList.rowData = myDataList;
            }
        }
    }
}
