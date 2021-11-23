using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    class BoolProperty : EditorPropertyItem
    {
        protected UICheckBox checkBox { get; set; }
        private float Height => 20f;

        public BoolProperty()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, Height);
            checkBox = AddUIComponent<UICheckBox>();

            Label = AddUIComponent<UILabel>();
            InitPanel();
        }

        protected override void InitPanel()
        {
            Label.text = "";
            Label.padding = Helper.Padding(ItemsPadding, ItemsPadding, ItemsPadding, ItemsPadding);
        }

        public void Init(bool defaultValue, string text)
        {
            base.Init();
            SetSize();
        }
        protected virtual void SetSize()
        {
            checkBox.size = new Vector2(width - ItemsPadding * 2, Height);
            checkBox.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);
        }


    }
}
