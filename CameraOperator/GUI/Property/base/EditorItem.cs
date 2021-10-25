using ColossalFramework.UI;
using System.Linq;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public abstract class EditorItem : UIPanel
    {
        protected virtual float DefaultHeight => 40;
        protected virtual int ItemsPadding => 14;
        public virtual bool EnableControl { get; set; } = true;

        // autoLayoutで並べるとbaseのUIPanelも含めてUIComponentが端によってしまう
        // 整列用のPanelを作成して中央揃えができるようにする
        public UIPanel Alignment { get; }
        public virtual bool SupportAlignment => true;

        public bool IsAlignment
        {
            get => Alignment.isVisible;
            set => Alignment.isVisible = value;
        }

        public EditorItem()
        {

                Alignment = AddUIComponent<UIPanel>();
                // Alignment.atlas = base.atlas;
                // Alignment.backgroundSprite = "EmptySprite";
                Alignment.name = "Alignment";
                Alignment.color = new Color32(0, 0, 0, 48);
                Alignment.size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            

            IsAlignment = false;
            color = Helper.RGB(50, 50, 50);
           // padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
            autoLayout = false;

        }

        public virtual void Init() => Init(null, null);
        public virtual void DeInit()
        {
            IsAlignment = false;
            EnableControl = true;
        }
        public void Init(float? width = null, float ? height = null)
        {
            size = new Vector2(width ?? DefaultHeight, height ?? DefaultHeight);
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

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();

            if (Alignment != null)
                Alignment.size = size;
        }

        public void SetAlignment()
        {
            if (!autoLayout)
                return;

            var supportEven = components.OfType<EditorItem>().Where(c => c.SupportAlignment && c.isVisible).ToArray();
            var alignment = supportEven.Length > 1;

            foreach (var item in supportEven)
            {
                item.IsAlignment = alignment;
                alignment = !alignment;
            }
        }

        public override string ToString() => name;
    }
}
