using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI.Property
{
    class Vector3Property : EditorPropertyItem
    {
        protected FieldType FieldX { get; set; }
        protected FieldType FieldY { get; set; }
        protected FieldType FieldZ { get; set; }

        public Vector3Property()
        {
            m_AutoLayout = true;
        }
    }
}
