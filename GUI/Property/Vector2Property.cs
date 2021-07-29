using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TokachiCinematicCameraMod.GUI.Property
{
    class Vector2Property : EditorPropertyItem
    {
        protected FieldType FieldX { get; set; }
        protected FieldType FieldY { get; set; }

        private float Height => 20f;

        public event Action<ValueType> OnValueChanged;

        public Vector2Property()
        {
            m_AutoLayout = true;

        }
        public override void Init()
        {
            base.Init();
            SetSize();
        }
        protected virtual void SetSize()
        {
            FieldX.size = new Vector2(width - ItemsPadding * 2, Height);
            FieldX.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);

            FieldY.size = new Vector2(width - ItemsPadding * 2, Height);
            FieldY.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);
        }
    }
}
