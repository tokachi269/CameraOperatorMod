﻿using CamOpr;
using ColossalFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CamOpr.Tool
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
            Vector3 position = CamOpr.CameraOperator.CameraController.m_currentPosition;
            float size = CamOpr.CameraOperator.CameraController.m_currentSize;
            float height = CamOpr.CameraOperator.CameraController.m_currentHeight;
            float fov = CamOpr.CameraOperator.MainCamera.fieldOfView;
            float num = size * (1f - (height / CamOpr.CameraOperator.CameraController.m_maxDistance)) / Mathf.Tan(0.017453292f * fov);
            Vector2 currentAngle = CamOpr.CameraOperator.CameraController.m_currentAngle;
            Quaternion rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up) * Quaternion.AngleAxis(currentAngle.y, Vector3.right);
            Vector3 worldPos = position + (rotation * new Vector3(0f, 0f, -num));

            return new CameraConfig(position, rotation, fov);
        }

        internal static void SetCamera(Vector3 pos, Quaternion rot)
        {
            CamOpr.CameraOperator.CameraController.m_currentPosition = pos;
            CamOpr.CameraOperator.CameraController.m_currentAngle = new Vector2(rot.x, rot.y);

        }

        public static void SetFreeCamera(bool value)
        {
            // if (UIView.isVisible == value)
            {
                try
                {
                    CamOpr.CameraOperator.EnsureUIComponentsLayout();
                    // UIView.Show(!value);
                }
                finally
                {
                    Singleton<NotificationManager>.instance.NotificationsVisible = !value;
                    Singleton<GameAreaManager>.instance.BordersVisible = !value;
                    Singleton<DistrictManager>.instance.NamesVisible = !value;
                    Singleton<PropManager>.instance.MarkersVisible = !value;
                    Singleton<GuideManager>.instance.TutorialDisabled = value;
                    if (value)
                    {
                        CamOpr.CameraOperator.MainCamera.rect = new Rect(0f, 0f, 1f, 1f);
                        CamOpr.CameraOperator.M_notificationAlpha.SetValue(Singleton<NotificationManager>.instance, 0f);
                    }
                    else
                    {
                        CamOpr.CameraOperator.MainCamera.rect = new Rect(0f, 0.105f, 1f, 0.895f);
                    }
                }
            }
        }
    }
}
