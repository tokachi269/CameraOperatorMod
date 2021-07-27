using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TokachiCinematicCameraMod.GUI.Property
{
    class EditorPropertyItem :EditorItem
    {
        private UILabel Label { get; set; }
        protected ContentPanel Content { get; set; }

        public string Text
        {
            get => Label.text;
            set => Label.text = value;
        }
        public override bool EnableControl
        {
            get => Content.isEnabled;
            set => Content.isEnabled = value;
        }
        public override bool SupportEven => true;

        public EditorPropertyItem()
        {
            Label = AddUIComponent<UILabel>();
            Label.textScale = 0.75f;
            Label.autoSize = false;
            Label.autoHeight = true;
            Label.wordWrap = true;
            Label.padding = new RectOffset(0, 0, 2, 0);
            Label.disabledTextColor = new Color32(160, 160, 160, 255);
            Label.name = nameof(Label);
            //Label.eventTextChanged += (_, _) => SetLabel();

            Content = AddUIComponent<ContentPanel>();
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
