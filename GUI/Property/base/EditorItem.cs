using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public abstract class EditorItem : UIPanel
    {
        protected virtual float DefaultHeight => 40;
        protected virtual int ItemsPadding => 14;
        public virtual bool EnableControl { get; set; } = true;
        //public UIPanel Content { get; }
        //public virtual bool SupportEven => false;
        //public bool IsEven
        //{
        //    get => Content.isVisible;
        //    set => Content.isVisible = value;
        //}
        public EditorItem()
        {
            //Content = AddUIComponent<UIPanel>();
            //Content.color = Helper.RGB(50, 50, 50);
            //Content.padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            //Content.autoLayout = false;
            //Content.name = "Content";
            //IsEven = false;
            color = Helper.RGB(50, 50, 50);
            padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            autoLayout = false;

        }
        public virtual void Init() => Init(null);
        //public virtual void DeInit()
        //{
        //    IsEven = false;
        //    EnableControl = true;
        //}
        public void Init(float? height = null)
        {
            size = new Vector2(GetWidth(), height ?? DefaultHeight);
        }
        private float GetWidth()
        {
            if (parent is UIScrollablePanel scrollablePanel)
                return scrollablePanel.width - scrollablePanel.autoLayoutPadding.horizontal - scrollablePanel.scrollPadding.horizontal;
            else if (parent is UIPanel panel)
                return panel.width - panel.autoLayoutPadding.horizontal;
            else
                return parent.width;
        }

    }
}
