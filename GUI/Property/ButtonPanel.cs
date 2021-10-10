using ColossalFramework.UI;

using System;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class ButtonPanel : EditorItem
    {
        UIButton button;

        public event Action OnButtonClick;

        private void ButtonClick(UIComponent component, UIMouseEventParameter eventParam) => OnButtonClick?.Invoke();

        public ButtonPanel()
        {
            size = new Vector2(40f, DefaultHeight);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            // autoFitChildrenVertically = true; //いらない
            clipChildren = false;
            autoLayout = false;
            builtinKeyNavigation = true;
            canFocus = true;
            color = Helper.RGB(50, 50, 50);

            button = AddUIComponent<UIButton>();
            button.normalBgSprite  = "ButtonWhitePressed";
            button.focusedBgSprite = "ButtonWhitePressed";
            button.pressedBgSprite = "ButtonWhitePressed";
            button.size = new Vector2(60, 60);

            button.color        = Helper.RGB(195, 195, 195);
            button.focusedColor = Helper.RGB(195, 195, 195);
            button.hoveredColor = Helper.RGB(170, 170, 170);
            button.pressedColor = Helper.RGB(120, 120, 120);

            button.textScale = 1f;
        }

        internal void Init(float width, float height, string text, float textScale)
        {
            button.size = new Vector2();
            SetSize(width, height);
            button.text = text;
            button.textScale = textScale;
            base.Init();
            //SetSize();
            }

            public void Init(String textt)
            {
            button.text = textt;
            
                base.Init();
                //SetSize();
            }

        protected virtual void SetSize(float width, float height)
        {
            button.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);
            button.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);
        }
    }
}
