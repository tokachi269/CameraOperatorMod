using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public abstract class EditorPropertyItem :EditorItem
    {
        public UILabel Label { get; set; }
        public bool hasLabel = false;
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
        }

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();
            //Refresh(false);
        }

        //protected void Refresh(bool refreshContent = true)
        //{
        //    if (refreshContent)
        //        //Alignment.Refresh();
        //
        //    Alignment.height = height;
        //    Alignment.relativePosition = new Vector2(width - Alignment.width - ItemsPadding, 0f);
        //
        //   // SetLabel();
        //}
    }
}
