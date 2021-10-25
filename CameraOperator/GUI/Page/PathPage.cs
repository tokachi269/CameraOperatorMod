using System;
using CameraOperator.Tool;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class PathPage :BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override CameraMode TabName => CameraMode.Path;

        public PathTool Tool;

        public void Awake()
        {
            base.Awake();
            CameraSettingPanel.AddButton.OnButtonClick += OnAddKnotButtonClick;
            void OnAddKnotButtonClick() => AddKnot();
            Tool = (PathTool)CameraOperatorMod.CameraOperator.Modes[new Tuple(TabName, "default")];

            CameraSettingPanel.AddButton.OnButtonClick += OnPlayButtonClick;
            void OnPlayButtonClick() => Play();

        }
        public void Start()
        {
            if (Tool != null)
            {
                Debug.Log("Adding knots failed!");
                Tool = new PathTool();
            }
        }

        public override void AddKnot()
        {

                var cameraConfig = CameraUtils.CaptureCamera();
                Tool.AddKnot(cameraConfig);
                ListPanel.addRow(cameraConfig, 0, true, true, true, true);
                Debug.Log("knot has been added");

        }

        public override void Play()
        {
            Debug.Log("Play");
            Tool.Play();

        }

    }
}
