﻿using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    internal class HeaderPanel : UIPanel
    {
		private UILabel title;
		private UIDragHandle dragHandle;

		public override void Awake()
		{
			base.Awake();

			title = AddUIComponent<UILabel>();

			clipChildren = true; // IMPORTANT
			AddUIComponent<UIPanel>();

			dragHandle = AddUIComponent<UIDragHandle>();
		}

		public override void Start()
		{
			base.Start();

			//base.name = "CameraOperator";
			backgroundSprite = "MenuPanel2";
			autoLayout = false;
			isInteractive = true;
			anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;
			color = Helper.RGB(255, 255, 255);
			size = new Vector2(CameraOperatorToolBase.DefaultRect.width, CameraOperatorToolBase.DefaultRect.height);

			color = Helper.RGB(255, 255, 255);
			zOrder = 0;
			clipChildren = true;

			title.text = "Camera Operator";
			title.width = 100;
			title.height = 200;
			title.relativePosition = new Vector3(18, 7, 0);
			var bulletSize = title.font.size + 4;
			var sprite = AddUIComponent<UISprite>();
			title.padding.left += bulletSize + 3;
			title.padding.left += 3;
			sprite.width = sprite.height = bulletSize;
			sprite.relativePosition = new Vector2(2, 0);
			sprite.spriteName = "InfoPanelIconFreecamera";

			dragHandle.target = parent;
			dragHandle.relativePosition = Vector3.zero;
			DebugUtils.Log("Camera Operator MainWindow created");

			UIButton uibutton = AddUIComponent<UIButton>();
			uibutton.size = new Vector2(30f, 30f);
			uibutton.text = "✕";
			uibutton.textScale = 0.9f;
			uibutton.textColor = Helper.RGB(118, 123, 123);
			uibutton.focusedTextColor = Helper.RGB(118, 123, 123);
			uibutton.hoveredTextColor = Helper.RGB(140, 142, 142);
			uibutton.pressedTextColor = Helper.RGBA(99, 102, 102, 102);
			uibutton.textPadding = new RectOffset(8, 8, 8, 8);
			uibutton.canFocus = false;
			uibutton.playAudioEvents = true;
			uibutton.relativePosition = new Vector3(width - uibutton.width, 0f);
			uibutton.eventClicked += delegate (UIComponent c, UIMouseEventParameter p)
			{
				if (isVisible)
				{
					CameraManeger.ToggleUI();
				}
			};
		}
	}
}