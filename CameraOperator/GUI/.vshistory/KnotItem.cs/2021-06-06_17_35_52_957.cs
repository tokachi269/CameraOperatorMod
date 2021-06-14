using CameraOperatorMod.GUI;
using CameraOperatorMod.mode;
using ColossalFramework.UI;
using System;


namespace TokachiCinematicCameraMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        UITextField probabilityTextField;
        UILabel treeNameLabel;
        bool initialized;

        private void Initialize(ControlPoint cp)
        {
            treeNameLabel = AddUIComponent<UILabel>();
            treeNameLabel.text = cp.position.x.ToString();
            treeNameLabel.autoSize = false;
            treeNameLabel.width = 255.0f;
            treeNameLabel.relativePosition = new Vector3(96.0f, 15.0f);
        }
        public void Deselect(bool isRowOdd)
        {
            throw new NotImplementedException();
        }

        public void Display(object data, bool isRowOdd)
        {
            if (!initialized) Initialize();
            throw new NotImplementedException();
        }

        public void Select(bool isRowOdd)
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            probabilityTextField = AddUIComponent<UITextField>();
        }
    }
}
