using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
	// Token: 0x0200000D RID: 13
	public class CameraOperatorButton : UIButton
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00004950 File Offset: 0x00002B50
		public override void Start()
		{
			//this.LoadResources();
			UIComponent uicomponent = base.GetUIView().FindUIComponent<UIComponent>("Freecamera");
			base.name = "CameraOperatorButton";
			base.tooltipBox = uicomponent.tooltipBox;
			base.tooltip = "Camera Operator Button";
			base.normalBgSprite = "OptionBase";
			base.disabledBgSprite = "OptionBaseDisabled";
			base.hoveredBgSprite = "OptionBaseHovered";
			base.pressedBgSprite = "OptionBasePressed";
			base.normalFgSprite = "ClapBoard";
			base.playAudioEvents = true;
			base.size = new Vector2(36f, 36f);
			if (CameraOperatorButton.savedX.value == -1000)
			{
				base.absolutePosition = new Vector2(uicomponent.absolutePosition.x - 2f * base.width - 19f, uicomponent.absolutePosition.y);
				return;
			}
			base.absolutePosition = new Vector2((float)CameraOperatorButton.savedX.value, (float)CameraOperatorButton.savedY.value);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004A5A File Offset: 0x00002C5A
		protected override void OnClick(UIMouseEventParameter p)
		{

			base.OnClick(p);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004A78 File Offset: 0x00002C78
		protected override void OnMouseDown(UIMouseEventParameter p)
		{
			if (p.buttons.IsFlagSet(UIMouseButton.Right))
			{
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.y = (float)this.m_OwnerView.fixedHeight - mousePosition.y;
				this.m_deltaPos = base.absolutePosition - mousePosition;
				this.BringToFront();
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004ACC File Offset: 0x00002CCC
		protected override void OnMouseMove(UIMouseEventParameter p)
		{
			if (p.buttons.IsFlagSet(UIMouseButton.Right))
			{
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.y = (float)this.m_OwnerView.fixedHeight - mousePosition.y;
				base.absolutePosition = mousePosition + this.m_deltaPos;
				CameraOperatorButton.savedX.value = (int)base.absolutePosition.x;
				CameraOperatorButton.savedY.value = (int)base.absolutePosition.y;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004B45 File Offset: 0x00002D45
		public void OnGUI()
		{
			if (!UIView.HasModalInput() && !UIView.HasInputFocus() && OptionsKeymapping.toggleUI.IsPressed(Event.current))
			{
				base.SimulateClick();
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004B6C File Offset: 0x00002D6C
		private void LoadResources()
		{
			Texture2D[] newTextures = new Texture2D[]
			{
				base.atlas["OptionBase"].texture,
				base.atlas["OptionBaseDisabled"].texture,
				base.atlas["OptionBaseHovered"].texture,
				base.atlas["OptionBasePressed"].texture
			};
			string[] spriteNames = new string[]
			{
				"ClapBoard"
			};
			//base.atlas = ResourceLoader.CreateTextureAtlas("CinematicCameraExtended", spriteNames, "CinematicCameraExtended.Icons.");
			//ResourceLoader.AddTexturesInAtlas(base.atlas, newTextures, false);
		}

		// Token: 0x0400003E RID: 62
		public static readonly SavedInt savedX = new SavedInt("mainButtonX", UserMod.SettingsFileName, -1000, true);

		// Token: 0x0400003F RID: 63
		public static readonly SavedInt savedY = new SavedInt("mainButtonY", UserMod.SettingsFileName, -1000, true);

		// Token: 0x04000040 RID: 64
		private Vector3 m_deltaPos;
	}
}
