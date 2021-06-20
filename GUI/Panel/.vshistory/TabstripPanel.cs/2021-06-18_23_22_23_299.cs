using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI.Panel
{
    class TabstripPanel: UITabstrip
    {
        public void AddTab(BaseTabPage editor)
        {
            var tab = AddTabImpl(editor.Name);
            tab.Editor = editor;
        }
    }
}
