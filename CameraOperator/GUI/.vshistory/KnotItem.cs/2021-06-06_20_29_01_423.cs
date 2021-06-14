using CameraOperatorMod.GUI;
using CameraOperatorMod.mode;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        UITextField probabilityTextField;
        UILabel posLabel;
        bool initialized;

        private void Initialize(ControlPoint cp)
        {
            width = parent.width;
            height = Constants.UIItemHeight;
            isVisible = true;
            isInteractive = true;
            tooltipBox.GetComponent<UILabel>().textAlignment = UIHorizontalAlignment.Left;
            GenerateTooltip(Prefab);
            eventTooltipEnter += TreeItem_eventTooltipEnter;
            eventMouseLeave += TreeItem_eventMouseLeave;

            posLabel = AddUIComponent<UILabel>();
            posLabel.text = cp.position.x.ToString();
            posLabel.autoSize = false;
            posLabel.width = 255.0f;
            posLabel.relativePosition = new Vector3(96.0f, 15.0f);
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
