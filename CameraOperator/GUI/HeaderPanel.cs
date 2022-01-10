using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    internal class HeaderPanel : UIPanel
    {
		private UILabel title;
		private UIDragHandle dragHandle;
		protected virtual float DefaultHeight => 30;

		public override void Awake()
		{
			base.Awake();

			title = AddUIComponent<UILabel>();

			clipChildren = true; // IMPORTANT

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
			size = new Vector2(CameraOperator.DefaultRect.width, CameraOperator.DefaultRect.height);

			color = Helper.RGB(255, 255, 255);
			zOrder = 0;
			clipChildren = true;

			title.text = "Camera Operator";
			title.width = 100;
			title.height = 200;
			title.relativePosition = new Vector3(18f, 8f, 0f);
			title.textColor = Helper.RGB(220, 220, 220);
			var bulletSize = title.font.size + 4;
			title.padding.left += bulletSize + 3;
			title.padding.left += 3;

            var sprite = AddUIComponent<UISprite>();
            sprite.width = sprite.height = bulletSize;
			sprite.relativePosition = new Vector2(12f, 4.5f);
			sprite.spriteName = "InfoPanelIconFreecamera";
            sprite.size = new Vector2(23f, 23f);

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
                parent.isVisible = !isVisible;
            };
		}

		public void Init(float? height = null)
		{
			size = new Vector2(CameraOperator.DefaultRect.width, height ?? DefaultHeight);
		}
	}
}