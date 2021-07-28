using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI.Property
{
    class FieldProperty : EditorPropertyItem
    {
        protected FieldType Field { get; set; }

        public event Action<ValueType> OnValueChanged;

        public FieldProperty()
        {
            Field = Content.AddUIComponent<FieldType>();
            //Field.SetDefaultStyle();
            Field.name = nameof(Field);
            m_AutoLayout = true;
            //Field.OnValueChanged += ValueChanged;
        }
    }
}
