using CamOpr.Tool;
using ColossalFramework.UI;
using System.Collections.Generic;
using UnityEngine;

namespace CamOpr.GUI
{
    public class ScrollablePanel : UIPanel
    {
        public UIFastList ListPanel;
        public PathDetailsPanel DetailPanel;
        public int DefaultHeight = 260;

        public void Awake()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            autoLayout = true;
            color = Helper.RGBA(255, 255, 255, 220);

            clipChildren = false;
            ListPanel = UIFastList.Create<KnotItem>(this);
            ListPanel.size = new Vector2(CameraOperator.DefaultRect.width / 3, DefaultHeight);
            ListPanel.relativePosition = new Vector2(0, 0);
            ListPanel.rowHeight = 20f;
            ListPanel.autoHideScrollbar = true;

            DetailPanel = AddUIComponent<PathDetailsPanel>();
            DetailPanel.size = new Vector2(CameraOperator.DefaultRect.width / 1.5f, DefaultHeight);
            DetailPanel.relativePosition = new Vector2(CameraOperator.DefaultRect.width / 3, 0);
            DetailPanel.backgroundSprite = "UnlockingItemBackground";
        }

        public void AddRow(List<CameraConfig> cameraConfigs)
        {
            FastList<object> cameraConfigs1 = new FastList<object>();
            for (int i = 0; i < cameraConfigs.Count; i++)
            {
                var item = cameraConfigs[i];
                item.ListIndex = i;
                cameraConfigs1.Add(item);
            }

            //InitDisplay(index, pos, rot, fov, zoom);
            ListPanel.rowsData = cameraConfigs1;
        }
    }
}