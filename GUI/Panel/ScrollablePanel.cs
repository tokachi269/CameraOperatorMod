using System.Collections.Generic;
using System.Collections.ObjectModel;
using CamOpr.Tool;
using ColossalFramework.UI;
using UnityEngine;
using static ColossalFramework.UI.UIColorPicker;

namespace CamOpr.GUI
{
    public class ScrollablePanel : UIPanel
    {
        public CameraMode TabMode { get; private set; }

        public UIFastList ListPanel;
        public PathDetailsPanel DetailPanel;
        public int DefaultHeight = 260;

        public void Awake()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            autoLayout = true;
            color = Helper.RGBA(255, 255, 255, 220);

            clipChildren = false;
            ListPanel = UIFastList.Create<KnotItemRow>(this);
            ListPanel.size = new Vector2(CameraOperator.DefaultRect.width / 3, DefaultHeight);
            ListPanel.relativePosition = new Vector2(0, 0);
            ListPanel.rowHeight = 20f;
            ListPanel.AutoHideScrollbar = true;
            ListPanel.CanSelect = true;

            DetailPanel = AddUIComponent<PathDetailsPanel>();
            DetailPanel.size = new Vector2(CameraOperator.DefaultRect.width / 1.5f, DefaultHeight);
            //DetailPanel.relativePosition = new Vector2(CameraOperator.DefaultRect.width / 3, 0);
            DetailPanel.backgroundSprite = "UnlockingItemBackground";
            DetailPanel.Content.autoLayout = true;
        }

        public void AddRow(ReadOnlyCollection<CameraConfig> cameraConfigs)
        {
            Reflesh(cameraConfigs);
        }

        public void RemoveRow(ReadOnlyCollection<CameraConfig> cameraConfigs)
        {
            Reflesh(cameraConfigs);
        }

        public void Reflesh(ReadOnlyCollection<CameraConfig> cameraConfigs)
        {
            FastList<object> cameraConfigs1 = new FastList<object>();
            int index = 0;

            foreach (var cp in cameraConfigs)
            {
                cp.ListIndex = index++;
                cameraConfigs1.Add(cp);
            }

            //InitDisplay(index, pos, rot, fov, zoom);
            ListPanel.rowsData = cameraConfigs1;
            if (cameraConfigs.Count == 1)
            {
                ListPanel.selectedIndex = 0;
            }
        }
    }
}