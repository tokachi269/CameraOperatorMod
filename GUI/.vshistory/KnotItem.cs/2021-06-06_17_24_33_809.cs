﻿using ColossalFramework.UI;
using ForestBrush.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        UITextField probabilityTextField;
        bool initialized;

        private void Initialize(TreeInfo info)
        { 
        
        }
            public void Deselect(bool isRowOdd)
        {
            throw new NotImplementedException();
        }

        public void Display(object data, bool isRowOdd)
        {
            if (!initialized) Initialize();
            throw new NotImplementedException();
        }

        public void Select(bool isRowOdd)
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            probabilityTextField = AddUIComponent<UITextField>();
        }
    }
}
