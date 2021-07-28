using ColossalFramework.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI.Property
{
    class ButtonPanel : EditorItem
    {
        UIButton button;

        public ButtonPanel()
        {
            button = AddUIComponent<UIButton>();
            m_AutoLayout = true;
        }
    }
}
