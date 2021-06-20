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
    public class Path :BaseTabPage<CameraConfigPanel, AdvancedScrollablePanel, PlaybackPanel>
    {
        public override string TabName => "Path";

        public Path()
        {
            CameraSettingPanel.padding = Helper.Padding(56, 2, 2, 2);
            CameraSettingPanel.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(56, 2, 2, 2));
        }
    }
}
