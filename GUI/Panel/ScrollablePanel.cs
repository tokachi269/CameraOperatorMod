using CameraOperator.Tool;
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
            autoLayout = true;

            clipChildren = false;
            ListPanel = UIFastList.Create<KnotItem>(this);
            ListPanel.size = new Vector2(CameraOperator.DefaultRect.width / 3, DefaultHeight);
            ListPanel.relativePosition = new Vector2(0,0);
            ListPanel.rowHeight = DefaultHeight;
            ListPanel.autoHideScrollbar = true;
            //for (int i = 0; i < 10; i++)
            //{
            //    ListPanel.rowsData.Add(null);
            //    ListPanel.rowsData.Add(new CameraConfig(Vector3.zero, Quaternion.identity, 60f,null));
            //}
        }
        
        public void addRow(CameraConfig cameraConfig, int index, bool pos, bool rot, bool fov, bool zoom)
        {
            //InitDisplay(index, pos, rot, fov, zoom);
            ListPanel.rowsData.Add(cameraConfig);
        }
    }
}