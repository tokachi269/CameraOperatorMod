using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CamOpr.GUI
{
    public abstract class EditorPropertyItem : EditorItem
    {
        public UILabel Label { get; set; }
        public ContentPanel Content { get; set; }

        public virtual bool HasLabel => false;

        public virtual bool hasUnit => false;

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
        public abstract void UpdateValues<T>(T value);

        public EditorPropertyItem()
        {
            autoLayout = false;

            if (HasLabel)
            {
                Label = AddUIComponent<UILabel>();
                Label.textScale = 0.75f;
                Label.autoSize = false;
                Label.autoHeight = true;
                Label.wordWrap = true;
                Label.padding = new RectOffset(0, 0, 2, 0);
                Label.disabledTextColor = Helper.RGB(160, 160, 160);
                Label.name = nameof(Label);
                Label.autoHeight = true;
                Label.padding = Helper.Padding((int)(DefaultHeight - GetLabelHeight()) / 2);

                //Label.eventTextChanged += (_, _) => SetLabel();
            }

            Content = AddUIComponent<ContentPanel>();
            Content.height = DefaultHeight;
        }

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();

            if (HasLabel) {
                Label.autoHeight = false;
                Label.autoHeight = true;
                Label.padding = Helper.Padding((int)(DefaultHeight - GetLabelHeight()) / 2);

                // Label.padding = Helper.Padding((int)(DefaultHeight - Label.height) / 2);
            }

            Refresh(false);
        }

        public void Refresh(bool refreshContent = true)
        {
            if (!(Content is null))
                Content.Refresh();

                Content.height = height;
                Content.relativePosition = new Vector2(width - Alignment.width - ItemsPadding, 0f);
                SetLabel();
        }

        private void SetLabel()
        {
            if (HasLabel)
            {
                Label.width = width - Content.width - ItemsPadding * 2;
                Label.MakePixelPerfect(false);
                Label.padding = Helper.Padding((int)(DefaultHeight - GetLabelHeight()) / 2);
                // Label.relativePosition = new Vector2(5, (height - Label.height) / 2);
            }

        }

        public class ContentPanel : UIPanel
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
                {
                    item.relativePosition = new Vector2(item.relativePosition.x, (height - item.height) / 2);
                }
            }

        }

        public float GetLabelHeight()
        {
            return Mathf.CeilToInt(Label.font.lineHeight * Label.textScale);
        }
    }
}
