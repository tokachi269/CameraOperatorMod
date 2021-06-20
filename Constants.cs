using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CameraOperatorMod
{
	public class ApplyItems
	{
		[DefaultValue(true)]
		public bool position { get; set; }

		[DefaultValue(true)]
		public bool rotation { get; set; }

		[DefaultValue(true)]
		public bool fov { get; set; }

		[DefaultValue(true)]
		public bool LookAt { get; set; }


		public ApplyItems(bool position, bool rotation, bool fov)
		{
			this.position = position;
			this.rotation = rotation;
			this.fov = fov;
		}
	}
}