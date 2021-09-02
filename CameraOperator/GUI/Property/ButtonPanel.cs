using ColossalFramework.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class ButtonPanel : EditorItem
    {
        UIButton button;

        public ButtonPanel()
        {
            size = new Vector2(60f, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = false;
            builtinKeyNavigation = true;
            canFocus = true;
            color = Helper.RGB(50, 50, 50);
            relativePosition = new Vector2(380f, 50f);

            button = AddUIComponent<UIButton>();
            button.normalBgSprite = "ButtonMenu";
            button.focusedBgSprite = "ButtonMenu";
            button.size = new Vector2(70, 70);
        }
        public override void Init()
        {
            base.Init();
            SetSize();
        }
        protected virtual void SetSize()
        {
            button.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);
            button.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);
        }
    }
}
