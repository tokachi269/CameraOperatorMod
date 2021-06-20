using CameraOperatorMod.mode;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class AdvancedScrollablePanel : UIPanel
    {
        UIFastList myFastList;

        public AdvancedScrollablePanel(){
            myFastList = UIFastList.Create<KnotItem>(parent);
            myFastList.size = new Vector2(200f, 300f);
            myFastList.rowHeight = 40f;
            myFastList.rowsData.Add(new ControlPoint(new Vector3(1, 1, 1), new Quaternion(0, 0, 0, 1), 60, false));
        }

    }
}