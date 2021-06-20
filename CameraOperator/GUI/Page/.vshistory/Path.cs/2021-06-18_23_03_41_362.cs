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
    public  class Path :BaseTabPage<CameraConfigPanel, AdvancedScrollablePanel, PlaybackPanel>
    {
        public override string Name => "Path";

        public Path()
        {
            CameraSettingPanel.padding = Helper.Padding(56, 2, 2, 2);
            CameraSettingPanel.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(56, 2, 2, 2));


            UIFastList myFastList = UIFastList.Create<KnotItem>(page);
            myFastList.size = new Vector2(200f, 300f);
            myFastList.rowHeight = 40f;
            myFastList.rowsData.Add(new ControlPoint(new Vector3(1, 1, 1), new Quaternion(0, 0, 0, 1), 60, false));

        }
    }
}
