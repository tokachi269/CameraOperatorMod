using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public abstract class EditorPropertyItem : EditorItem
    {
        public UILabel Label { get; set; }
        protected ContentPanel Content { get; set; }

        public virtual bool hasLabel => false;

        public string Text
        {
            get => Label.text;
            set => Label.text = value;
        }

        public override bool EnableControl
        {
            get => isEnabled;
            set => isEnabled = value;
        }

        public override bool SupportAlignment => true;

        protected abstract void InitPanel();

        public EditorPropertyItem()
        {
            autoLayout = false;

            if (hasLabel)
            {
                Label = AddUIComponent<UILabel>();
                Label.textScale = 0.75f;
                Label.autoSize = false;
                Label.autoHeight = true;
                Label.wordWrap = true;
                Label.padding = new RectOffset(0, 0, 2, 0);
                Label.disabledTextColor = Helper.RGB(160, 160, 160);
                Label.name = nameof(Label);
                //Label.eventTextChanged += (_, _) => SetLabel();
            }

            Content = AddUIComponent<ContentPanel>();
        }

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();
            Refresh(false);
        }

        protected void Refresh(bool refreshContent = true)
        {
            if (refreshContent)
                //Alignment.Refresh();
        
            Alignment.height = height;
            Alignment.relativePosition = new Vector2(width - Alignment.width - ItemsPadding, 0f);
        
          // SetLabel();
        }
        private void SetLabel()
        {
            Label.width = width - Content.width - ItemsPadding * 2;
            Label.MakePixelPerfect(false);
            Label.relativePosition = new Vector2(5, (height - Label.height) / 2);
        }

        protected class ContentPanel : UIPanel
        {
            public ContentPanel()
            {
                autoLayoutDirection = LayoutDirection.Horizontal;
                autoFitChildrenHorizontally = true;
                autoLayoutPadding = new RectOffset(5, 0, 0, 0);
                name = nameof(Content);
            }

            protected override void OnSizeChanged()
            {
                base.OnSizeChanged();
                Refresh();
            }
            public void Refresh()
            {
                autoLayout = true;
                autoLayout = false;

                foreach (var item in components)
                    item.relativePosition = new Vector2(item.relativePosition.x, (height - item.height) / 2);
            }
        }
    }
}
