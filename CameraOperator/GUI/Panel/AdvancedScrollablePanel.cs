using CameraOperatorMod;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class AdvancedScrollablePanel : UIPanel
    {
        UIFastList FastList;

        public void Awake()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, 200);
            padding = Helper.Padding(4, 12, 4, 0);
            autoFitChildrenVertically = true;
            clipChildren = false;
            // FastList = UIFastList.Create<KnotItem>(this);
            // FastList.size = new Vector2(width / 3, 300f);
            // FastList.rowHeight = 40f;
            // FastList.rowsData.Add(new ControlPoint(new Vector3(1, 1, 1), new Quaternion(0, 0, 0, 1), 60));
        }
    }
}