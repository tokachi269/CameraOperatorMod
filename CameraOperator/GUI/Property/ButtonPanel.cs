using ColossalFramework.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class ButtonPanel : EditorItem
    {
        UIButton button;
        private float Height => 20f;

        public ButtonPanel()
        {
            button = AddUIComponent<UIButton>();
            m_AutoLayout = true;
        }
        public override void Init()
        {
            base.Init();
            SetSize();
        }
        protected virtual void SetSize()
        {
            button.size = new Vector2(width - ItemsPadding * 2, Height);
            button.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);
        }
    }
}
