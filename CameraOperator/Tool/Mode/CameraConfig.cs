
using UnityEngine;
using System.ComponentModel;

namespace CamOpr.Tool
{
	public class CameraConfig
	{
		public int ListIndex = -1;

		public Vector3 Position;

		public Quaternion Rotation;

		public float Length;

		public float Size;

		public float Height;

		[DefaultValue(2f)]
		public float Duration = 2f;

		[DefaultValue(0f)]
		public float Delay;

		[DefaultValue(45f)]
		public float Fov;

		public ApplyItems ApplyItems = new ApplyItems(true, true, true);

		[DefaultValue(EasingMode.Auto)]
		public EasingMode EasingMode;

		public bool IsLookAt;

		public CameraConfig(Vector3 position, Quaternion rotation, float fov ,bool? isLookAt = null)
		{
			this.Position = position;
			this.Rotation = rotation;
			this.Fov = fov;
			//this.CaptureCamera();
			this.EasingMode = EasingMode.Auto;
			Delay = 0f;
			this.IsLookAt = isLookAt != null && (bool)isLookAt;
		}
    }
}
