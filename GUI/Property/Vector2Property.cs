using System;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class Vector2Property : EditorPropertyItem
    {
        protected FieldType FieldX { get; set; }
        protected FieldType FieldY { get; set; }
        public override bool HasLabel => true;

        public event Action<ValueType> OnValueChanged;

        public Vector2Property()
        {
            autoLayout = true;
            FieldX = AddUIComponent<FieldType>();
            FieldY = AddUIComponent<FieldType>();

            InitPanel();
        }

        protected override void InitPanel()
        {
            autoLayout = true;

            autoLayoutDirection = LayoutDirection.Horizontal;
            padding = Helper.Padding(0, 0, 0, 14);
            clipChildren = false;

            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            FieldX.size = new Vector2(width - (ItemsPadding * 2), DefaultHeight);

            FieldX.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);
            FieldY.size = new Vector2(width - (ItemsPadding * 2), DefaultHeight);

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

        public override void UpdateValues<T>(T value)
        {
            if (value is Vector2)
            {
                Vector2 vector3 = (Vector2)(object)value;
                FieldX.text = vector3.x.ToString();
                FieldY.text = vector3.y.ToString();
            }
            else
            {
                Debug.Log("Must be a Vector2 type");
            }
        }
    }
}
