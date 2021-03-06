using CamOpr.Tool;
using System.Collections;
using UnityEngine;

namespace CamOpr.GUI
{
    public class RotatePage : BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override CameraMode TabName => CameraMode.Rotate;

        public RotateTool Tool;

        public void Awake()
        {
            base.Awake();
            CameraSettingPanel.AddButton.OnButtonClick += OnAddKnotButtonClick;
            void OnAddKnotButtonClick() => AddKnot();
            Tool = (RotateTool)CamOpr.CameraOperator.Modes[new Tuple(TabName, "default")];

            CameraSettingPanel.AddButton.OnButtonClick += OnPlayButtonClick;
            void OnPlayButtonClick() => Play();
        }

        public override void AddKnot()
        {
            var controlPoint = CameraUtils.CaptureCamera();
            //.addRow(0, true, true, true, true);
        }

        public override void Play()
        {
            Debug.Log("Play");
            Tool.Play();
        }
    }
}
