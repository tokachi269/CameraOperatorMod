using CameraOperatorMod;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class ScrollablePanel : UIPanel
    {
        public UIFastList ListPanel;
        public int DefaultHeight = 260;

        public void Awake()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            autoFitChildrenVertically = true;
            autoLayout = false;
            clipChildren = false;
           // ListPanel = UIFastList.Create<KnotItem>(this);
           // ListPanel.size = new Vector2(CameraOperator.DefaultRect.width / 3, DefaultHeight);
           // ListPanel.relativePosition = new Vector2(0,0);
           // ListPanel.rowHeight = 40f;
        }
        public void addRows(int index, bool pos, bool rot, bool fov, bool zoom)
        {
            var row = AddUIComponent<KnotItem>();
            row.InitDisplay(index, pos, rot, fov, zoom);
           // ListPanel.rowsData.Add(row);

        }
    }
}