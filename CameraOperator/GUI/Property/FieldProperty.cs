using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class FieldProperty : EditorPropertyItem
    {
        private FieldType Field;
        private float Height => 20f;

        public event Action<ValueType> OnValueChanged;

        public FieldProperty()
        {
            Field = Content.AddUIComponent<FieldType>();
            //Field.SetDefaultStyle();
            Field.name = nameof(Field);
            m_AutoLayout = true;
            //Field.OnValueChanged += ValueChanged;
        }
        public override void Init()
        {
            base.Init();
            SetSize();
        }
        protected virtual void SetSize()
        {
            Field.size = new Vector2(width - ItemsPadding * 2, Height);
            Field.relativePosition = new Vector3(ItemsPadding, (height - Height) / 2);
        }
    }
}
