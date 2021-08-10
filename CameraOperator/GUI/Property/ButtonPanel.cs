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
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = false;
            builtinKeyNavigation = true;
            canFocus = true;
            color = Helper.RGB(50, 50, 50);
            relativePosition = new Vector2(0, 0);

            button = AddUIComponent<UIButton>();
            button.normalBgSprite = "ButtonMenu";
            button.focusedBgSprite = "ButtonMenu";
            button.size = new Vector2(70, 22);
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
