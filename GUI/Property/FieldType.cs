using ColossalFramework.UI;

namespace TokachiCinematicCameraMod.GUI.Property
{
    internal class FieldType: UIPanel
    {
        UITextField textField;
        public FieldType()
        {
            textField = AddUIComponent<UITextField>();
            m_AutoLayout = true;
        }

    }
}