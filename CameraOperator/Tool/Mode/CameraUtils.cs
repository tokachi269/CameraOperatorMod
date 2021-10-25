using CameraOperatorMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperator.Tool
{
    public static class CameraUtils
    {
        public static CameraConfig CameraPosition()
        {
            return new CameraConfig(Camera.main.transform.position, Camera.main.transform.rotation, Camera.main.fieldOfView);
        }

        /*P2をP1から回転が少ない方向に回転するように補正する*/
        public static Vector3 ClosestAngle(Vector3 basePoint, Vector3 point)
        {
            Vector3 A = basePoint - point;
            if (A.x > 180f)
            {
                point.x += 360f;
            }
            else if (A.x < -180f)
            {
                point.x -= 360f;
            }
            if (A.y > 180f)
            {
                point.y += 360f;
            }
            else if (A.y < -180f)
            {
                point.y -= 360f;
            }
            if (A.z > 180f)
            {
                point.z += 360f;
            }
            else if (A.z < -180f)
            {
                point.z -= 360f;
            }
            return point;
        }

        public static CameraConfig CaptureCamera()
        {
            Vector3 position = CameraOperatorMod.CameraOperator.cameraController.m_currentPosition;
            float size = CameraOperatorMod.CameraOperator.cameraController.m_currentSize;
            float height = CameraOperatorMod.CameraOperator.cameraController.m_currentHeight;
            float fov = CameraOperatorMod.CameraOperator.mainCamera.fieldOfView;
            float num = size * (1f - (height / CameraOperatorMod.CameraOperator.cameraController.m_maxDistance)) / Mathf.Tan(0.017453292f * fov);
            Vector2 currentAngle = CameraOperatorMod.CameraOperator.cameraController.m_currentAngle;
            Quaternion rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up) * Quaternion.AngleAxis(currentAngle.y, Vector3.right);
            Vector3 worldPos = position + (rotation * new Vector3(0f, 0f, -num));

            return new CameraConfig(position, rotation, fov);
        }

        internal static void setCamera(Vector3 pos, Quaternion rot)
        {
            CameraOperatorMod.CameraOperator.cameraController.m_currentPosition = pos;
            CameraOperatorMod.CameraOperator.cameraController.m_currentAngle = new Vector2(rot.x, rot.y);

        }
    }
}
