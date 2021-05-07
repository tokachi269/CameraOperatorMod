using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod
{
    class Segments
    {
		public void CaptureCamera()
		{
		//	this.position = CameraManeger.cameraController.m_currentPosition;
		//	this.size = CameraManeger.cameraController.m_currentSize;
		//	this.height = CameraManeger.cameraController.m_currentHeight;
		//	this.fov = CameraManeger.camera.fieldOfView;
		//	float num = this.size * (1f - this.height / CameraManeger.cameraController.m_maxDistance) / Mathf.Tan(0.017453292f * this.fov);
		//	Vector2 currentAngle = CameraManeger.cameraController.m_currentAngle;
		//	this.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up) * Quaternion.AngleAxis(currentAngle.y, Vector3.right);
		//	Vector3 worldPos = this.position + this.rotation * new Vector3(0f, 0f, -num);
		//	this.position.y = this.position.y + Knot.CalculateCameraHeightOffset(worldPos, num);
		}
		public Vector3 position;
        public Vector3 rotation;
        public float fov;

    }
    

}
