using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
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