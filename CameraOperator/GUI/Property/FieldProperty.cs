using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CamOpr.GUI
{
    public class FieldProperty : EditorPropertyItem
    {
        public FieldType Field { get; set; }

        public override int ItemsPadding => 4;
        public override float DefaultHeight => 28;
        public override bool HasLabel => true;

        public event Action<ValueType> OnValueChanged;
        
        public FieldProperty()
        {
            Field = Content.AddUIComponent<FieldType>();
            InitPanel();
        }

        protected override void InitPanel()
        {
            autoLayoutDirection = LayoutDirection.Horizontal;
            clipChildren = false;
            autoLayoutPadding = Helper.Padding(0, ItemsPadding, 0, ItemsPadding);

            autoLayout = true;

            Label.width = base.width - Content.width;
        }

/*        protected override void OnSizeChanged()
        {
            SetSize();
            Refresh(false);
        }*/

        public override void Init()
        {
            base.Init();
            SetSize();
        }

        protected virtual void SetSize(float? width = null, float? height = null)
        {
            if (!(Field is null))
            {
                if (!(width is null)) base.width = Field.width;
                //if (!(height is null)) Field.height = (float)height;

                base.size = Field.size;
            }
            base.OnSizeChanged();
        }

        protected void Refresh(bool refreshContent = true)
        {
            if (!(Field is null))
            {
                Field.height = height;
              // Content.relativePosition = new Vector2(width - Content.width - ItemsPadding, 0f);
            }
        }

        private void SetLabel()
        {
            Label.width = width - Field.width - ItemsPadding * 2;
            Label.MakePixelPerfect(false);
           // Label.relativePosition = new Vector2(5, (height - Label.height) / 2);
        }

        public override void UpdateValues<T>(T value)
        {
            Field.text = value.ToString();
        }
    }
}
