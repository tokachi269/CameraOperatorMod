using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        UITextField probabilityTextField;
        private void Initialize()
        {
            probabilityTextField = AddUIComponent<UITextField>();
        }
}
