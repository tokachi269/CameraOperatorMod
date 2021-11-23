using CamOpr.Tool;
using System;
using System.Collections;
using UnityEngine;

namespace CamOpr.GUI
{
    public class PathPage : BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override CameraMode TabName => CameraMode.Path;

        private PathTool tool;

        public void Awake()
        {
            base.Awake();
            CameraSettingPanel.AddButton.OnButtonClick += OnAddKnotButtonClick;
            void OnAddKnotButtonClick() => AddKnot();
            tool = (PathTool)CamOpr.CameraOperator.Modes[new Tuple(TabName, "default")];

            PlayPanel.PlaybackButton.OnButtonClick += OnPlayButtonClick;
            void OnPlayButtonClick() => Play();
        }

        public void Start()
        {
            if (tool != null)
            {
                Debug.Log("Adding knots failed!");
                tool = new PathTool();
            }
        }

        public override void AddKnot()
        {
                var cameraConfig = CameraUtils.CaptureCamera();
                tool.AddKnot(cameraConfig);
                ListPanel.AddRow(tool.Knots);
                Debug.Log("knot has been added");
        }

        public override void Play()
        {
            CameraUtils.SetFreeCamera(true);
            tool.StartPlay();

            // Tool.Play();
        }
    }
}
