﻿using CameraOperatorMod;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        static float ItemHeight = 20f;
        
        UILabel IndexLabel;

        bool initialized;
        public void Initialize() => Initialize(null, 0);
        public void Initialize(ControlPoint cp, int index)
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
        }

        internal void InitDisplay(int index, bool pos, bool rot, bool fov, bool zoom)
        {
            IndexLabel.text = index.ToString();
            if (pos)
            {
                AddUIComponent<UISprite>();
            }
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

    }
}
