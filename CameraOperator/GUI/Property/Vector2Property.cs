using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CamOpr.GUI
{
    public class Vector2Property : EditorPropertyItem
    {
        protected FieldProperty FieldX { get; set; }
        protected FieldProperty FieldY { get; set; }
        public override bool hasLabel => true;

        public event Action<ValueType> OnValueChanged;

        public Vector2Property()
        {
            autoLayout = true;
            FieldX = AddUIComponent<FieldProperty>();
            FieldY = AddUIComponent<FieldProperty>();

            InitPanel();
        }

        protected override void InitPanel()
        {
            autoLayout = true;

            autoLayoutDirection = LayoutDirection.Horizontal;
            padding = Helper.Padding(0, 0, 0, 14);
            clipChildren = false;

            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            FieldX.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);

            FieldX.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);
            FieldY.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);

            FieldY.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);
            Content.autoLayout = true;

        }

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();
            SetSize();
        }

        public override void Init()
        {
            base.Init();
            SetSize();
        }

        protected virtual void SetSize(float? width = null, float? height = null)
        {

            base.OnSizeChanged();

        }
    }
}
