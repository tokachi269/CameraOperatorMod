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
        public void AddTab(BaseTabPage tabPage)
        {
            var tab = TabButton(tabPage.Name, true);
            tab.BaseTabPage = editor;
        }

        private object TabButton(String name, bool fillText)
        {
            throw new NotImplementedException();
        }
    }
}
