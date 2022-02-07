using CamOpr.Tool;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class PathPage : BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override CameraMode TabMode => CameraMode.Path;

        private PathTool tool;

        public void Awake()
        {
            base.Awake();

            tool = (PathTool)CamOpr.CameraOperator.Modes[new Tuple(TabMode, "default")];

            CameraSettingPanel.AddButton.OnButtonClick += OnAddKnotButtonClick;
            void OnAddKnotButtonClick() => AddKnot();

            PlayPanel.PlaybackButton.OnButtonClick += OnPlayButtonClick;
            void OnPlayButtonClick() => Play();

            ListPanel.ListPanel.eventSelectedIndexChanged += RefreshDetailPanel;

            var button = (ButtonProperty)ListPanel.DetailPanel.Propertys[PathDetailsPanel.EPropaties.Button];
            button.OnButtonClick += OnRemoveKnotButtonClick;
            void OnRemoveKnotButtonClick() => RemoveKnot();
        }

        public void Start()
        {
            if (tool != null)
            {
                Debug.Log("Adding knots failed!");

                tool = new GameObject("tool").AddComponent<PathTool>();

            }
        }

        public void RefreshDetailPanel(UIComponent component, int index)
        {
            Debug.Log("Detail display" + index);

            CameraConfig cp = tool.Knots[index];
            ListPanel.DetailPanel.Refresh(cp);

        }
        public override void AddKnot()
        {
                var cameraConfig = CameraUtils.CaptureCamera();
                tool.AddKnot(cameraConfig);
                ListPanel.AddRow(tool.Knots);
                Debug.Log("knot has been added");
        }

        public override void RemoveKnot()
        {
            int index = ListPanel.ListPanel.selectedIndex;
            tool.RemoveKnot();
            ListPanel.Reflesh(tool.Knots);
            Debug.Log("knot has been removed");
        }

        public override void Play()
        {
            CameraUtils.SetFreeCamera(true);
            tool.StartPlay();

            // Tool.Play();
        }
    }
}
