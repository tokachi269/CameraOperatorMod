using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CamOpr.GUI
{
    public class ButtonType: UIButton
    {
        public event Action OnButtonClick;

        public void ButtonClick(UIComponent component, UIMouseEventParameter eventParam) => OnButtonClick?.Invoke();

        public ButtonType()
        {
            this.normalBgSprite = "ButtonWhitePressed";
            this.focusedBgSprite = "ButtonWhitePressed";
            this.pressedBgSprite = "ButtonWhitePressed";
            this.size = new Vector2(60, 60);
            
            this.color = Helper.GrayScale(195);
            this.focusedColor = Helper.GrayScale(195);
            this.hoveredColor = Helper.GrayScale(180);
            this.pressedColor = Helper.GrayScale(140);

            textScale = 1f;
            eventClick += ButtonClick;
        }

    protected override void OnSizeChanged()
        {
            base.OnSizeChanged();
        }
    }
}