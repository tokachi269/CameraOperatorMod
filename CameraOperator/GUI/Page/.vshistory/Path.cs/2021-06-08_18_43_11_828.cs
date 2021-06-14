using CameraOperatorMod.GUI;
using CameraOperatorMod.mode;
using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public  class Path :BaseTabPagePanel<CameraConfigPanel, AdvancedScrollablePanel, PlaybackPanel>
    {
        public static void Setup(ref UIPanel page)
        {
            page.padding = Helper.Padding(56, 2, 2, 2);
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

            UIFastList myFastList = UIFastList.Create<KnotItem>(page);
            myFastList.size = new Vector2(200f, 300f);
            myFastList.rowHeight = 40f;
            myFastList.rowsData.Add(new ControlPoint(new Vector3(1, 1, 1), new Quaternion(0, 0, 0, 1), 60, false));

        }
    }
}
