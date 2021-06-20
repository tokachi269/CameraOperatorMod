using System;
using System.Linq;
using ColossalFramework;
using ColossalFramework.UI;

using UnityEngine;

namespace CameraOperatorMod.GUI
{
	struct TabTemplate
	{
		public string name;
	}

	public class CameraOperator : UIPanel
	{
		private UILabel title;
		private UIDragHandle dragHandle;
		private UIPanel content_;
        public UIPanel Content { get => content_; }

		public override void Awake()
        {
			base.Awake();

			title = AddUIComponent<UILabel>();

			clipChildren = true; // IMPORTANT
			content_ = AddUIComponent<UIPanel>();

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

			content_.color = Helper.RGB(255, 255, 255);
			content_.zOrder = 0;
			content_.clipChildren = true;

			title.text = "Camera Operator";
			title.width = 100;
			title.height = 200;
			title.relativePosition = Helper.Padding(18, 7);

			dragHandle.target = parent;
			dragHandle.relativePosition = Vector3.zero;
			DebugUtils.Log("UIMainWindow created");

			UIButton uibutton = AddUIComponent<UIButton>();
			uibutton.size = new Vector2(30f, 30f);
			uibutton.text = "✕";
			uibutton.textScale = 0.9f;
			uibutton.textColor = new Color32(118, 123, 123, byte.MaxValue);
			uibutton.focusedTextColor = new Color32(118, 123, 123, byte.MaxValue);
			uibutton.hoveredTextColor = new Color32(140, 142, 142, byte.MaxValue);
			uibutton.pressedTextColor = new Color32(99, 102, 102, 102);
			uibutton.textPadding = new RectOffset(8, 8, 8, 8);
			uibutton.canFocus = false;
			uibutton.playAudioEvents = true;
			uibutton.relativePosition = new Vector3(width - uibutton.width, 0f);
			uibutton.eventClicked += delegate(UIComponent c, UIMouseEventParameter p)
			{
				if (isVisible)
				{
					CameraManeger.ToggleUI();
				}
			};

			//UIPanel uipanel = base.AddUIComponent<UIPanel>();
			//uipanel.atlas = base.atlas;
			//uipanel.backgroundSprite = "GenericPanel";
			//uipanel.color = new Color32(206, 206, 206, byte.MaxValue);
			//uipanel.size = new Vector2(base.width - 16f, 46f);
			//uipanel.relativePosition = new Vector2(8f, 28f);


			//UIButton addKnotButton = SamsamTS.UIUtils.CreateButton(uipanel);
			//addKnotButton.name = "CCX_AddKnot";
			//addKnotButton.textScale = 1.5f;
			//addKnotButton.text = "+";
			//addKnotButton.size = new Vector2(40f, 30f);
			//addKnotButton.relativePosition = new Vector3(8f, 8f);
			//addKnotButton.tooltip = "Add a new point to the path";
			//addKnotButton.eventClicked += delegate (UIComponent c, UIMouseEventParameter p)
			//{
			//	int num = CameraManeger.cameraPath.AddKnot();
			//	this.fastList.DisplayAt((float)num);
			//	this.timelineSlider.minValue = 0f;
			//	float num2 = CameraManeger.cameraPath.CalculateTotalDuraction();
			//	if (num2 <= 0f)
			//	{
			//		num2 = 1f;
			//	}
			//	this.timelineSlider.maxValue = num2;
			//};
		}

	}
}
