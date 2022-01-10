using System;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class ButtonPanel : EditorItem
    {
        UIButton button;

        public event Action OnButtonClick;

        public void ButtonClick(UIComponent component, UIMouseEventParameter eventParam) => OnButtonClick?.Invoke();

        public ButtonPanel()
        {
            size = new Vector2(40f, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = false;
            builtinKeyNavigation = true;
            canFocus = true;
            color = Helper.GrayScale(50);

            button = AddUIComponent<UIButton>();
            button.normalBgSprite  = "ButtonWhitePressed";
            button.focusedBgSprite = "ButtonWhitePressed";
            button.pressedBgSprite = "ButtonWhitePressed";
            button.size = new Vector2(60, 60);

            button.color        = Helper.GrayScale(195);
            button.focusedColor = Helper.GrayScale(195);
            button.hoveredColor = Helper.GrayScale(180);
            button.pressedColor = Helper.GrayScale(140);

            button.textScale = 1f;
            button.eventClick += ButtonClick;
        }

        internal void Init(float width, float height, string text, float textScale)
        {
            button.text = text;
            button.textScale = textScale;
            base.Init(width + padding.horizontal, height + padding.vertical);
            SetSize(width, height);
        }

        protected virtual void SetSize(float width, float height)
        {
            button.size = new Vector2(width, height);
            button.relativePosition = new Vector3(ItemsPadding, ItemsPadding);
        }
    }
}
