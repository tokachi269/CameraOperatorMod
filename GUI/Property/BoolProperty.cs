﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class BoolProperty : EditorItem
    {
        protected UICheckBox checkBox;
        protected UILabel label;
        private float Height => 20f;

        public BoolProperty()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, Height);
            checkBox = AddUIComponent<UICheckBox>();

            label = AddUIComponent<UILabel>();
            label.text = "";
            label.padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
        }

        public override void Init()
        {
            base.Init();
            SetSize();
        }
        protected virtual void SetSize()
        {
            checkBox.size = new Vector2(width - ItemsPadding * 2, Height);
            checkBox.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);
        }
    }
}
