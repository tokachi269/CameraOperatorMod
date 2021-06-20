using CameraOperatorMod.GUI;
using CameraOperatorMod.mode;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        static float ItemHeight = 20f;
        UITextField probabilityTextField;
        
        UILabel IndexLabel;

        UILabel posLabel;
        bool initialized;

        private void Initialize(ControlPoint cp)
        {
            width = parent.width;
            height = ItemHeight;
            isVisible = true;
            isInteractive = true;
            tooltipBox.GetComponent<UILabel>().textAlignment = UIHorizontalAlignment.Left;
            //GenerateTooltip(Prefab);
            //eventTooltipEnter += TreeItem_eventTooltipEnter;
            //eventMouseLeave += TreeItem_eventMouseLeave;

            IndexLabel = AddUIComponent<UILabel>();
            IndexLabel.text = index.ToString();
            IndexLabel.autoSize = false;
            IndexLabel.width = 255.0f;

            posLabel = AddUIComponent<UILabel>();
            posLabel.text = cp.position.x.ToString();
            posLabel.autoSize = false;
            posLabel.width = 255.0f;
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
