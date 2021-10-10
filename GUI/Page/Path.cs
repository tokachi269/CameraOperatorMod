using System;
using CameraOperator.Tool;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class Path :BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override string TabName => "Path";

        public PathTool Tool => PathTool.Instance;

        public void Awake()
        {
            base.Awake();
            CameraSettingPanel.ButtonPanel.OnButtonClick += OnButtonClick;
            void OnButtonClick() => AddKnot();

        }
        public override void AddKnot()
        {
            var controlPoint = CaptureCamera();

            ListPanel.addRow(0, true, true, true, true);
        }

        public CameraConfig CaptureCamera()
        {
            Vector3 position = CameraManeger.cameraController.m_currentPosition;
            float size = CameraManeger.cameraController.m_currentSize;
            float height = CameraManeger.cameraController.m_currentHeight;
            float fov = CameraManeger.mainCamera.fieldOfView;
            float num = size * (1f - (this.height / CameraManeger.cameraController.m_maxDistance)) / Mathf.Tan(0.017453292f * fov);
            Vector2 currentAngle = CameraManeger.cameraController.m_currentAngle;
            Quaternion rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up) * Quaternion.AngleAxis(currentAngle.y, Vector3.right);
            Vector3 worldPos = position + (rotation * new Vector3(0f, 0f, -num));

            return new CameraConfig(position, rotation, fov);
        }
    }
}
