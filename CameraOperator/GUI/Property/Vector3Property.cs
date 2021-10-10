namespace CameraOperatorMod.GUI
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
