using System;
using System.Reflection;
using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.UI;
using UnityEngine;
using CameraOperatorMod;

namespace CameraOperatorMod
{
	// Token: 0x0200000A RID: 10
	public class OptionsKeymapping : UICustomControl
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00003D20 File Offset: 0x00001F20
		private void Awake()
		{
			this.AddKeymapping("Toggle UI", OptionsKeymapping.toggleUI);
			this.AddKeymapping("Add point", OptionsKeymapping.addPoint);
			this.AddKeymapping("Remove point", OptionsKeymapping.removePoint);
			this.AddKeymapping("Play", OptionsKeymapping.play);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003D70 File Offset: 0x00001F70
		private void AddKeymapping(string label, SavedInputKey savedInputKey)
		{
			UIPanel uipanel = base.component.AttachUIComponent(UITemplateManager.GetAsGameObject(OptionsKeymapping.kKeyBindingTemplate)) as UIPanel;
			int num = this.count;
			this.count = num + 1;
			if (num % 2 == 1)
			{
				uipanel.backgroundSprite = null;
			}
			UILabel uilabel = uipanel.Find<UILabel>("Name");
			UIButton uibutton = uipanel.Find<UIButton>("Binding");
			uibutton.eventKeyDown += this.OnBindingKeyDown;
			uibutton.eventMouseDown += this.OnBindingMouseDown;
			uilabel.text = label;
			uibutton.text = savedInputKey.ToLocalizedString("KEYNAME");
			uibutton.objectUserData = savedInputKey;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003E0E File Offset: 0x0000200E
		private void OnEnable()
		{
			LocaleManager.eventLocaleChanged += this.OnLocaleChanged;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003E21 File Offset: 0x00002021
		private void OnDisable()
		{
			LocaleManager.eventLocaleChanged -= this.OnLocaleChanged;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003E34 File Offset: 0x00002034
		private void OnLocaleChanged()
		{
			this.RefreshBindableInputs();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003E3C File Offset: 0x0000203C
		private bool IsModifierKey(KeyCode code)
		{
			return code == KeyCode.LeftControl || code == KeyCode.RightControl || code == KeyCode.LeftShift || code == KeyCode.RightShift || code == KeyCode.LeftAlt || code == KeyCode.RightAlt;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003E70 File Offset: 0x00002070
		private bool IsControlDown()
		{
			return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003E8A File Offset: 0x0000208A
		private bool IsShiftDown()
		{
			return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003EA4 File Offset: 0x000020A4
		private bool IsAltDown()
		{
			return Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003EBE File Offset: 0x000020BE
		private bool IsUnbindableMouseButton(UIMouseButton code)
		{
			return code == UIMouseButton.Left || code == UIMouseButton.Right;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003ECC File Offset: 0x000020CC
		private KeyCode ButtonToKeycode(UIMouseButton button)
		{
			if (button == UIMouseButton.Left)
			{
				return KeyCode.Mouse0;
			}
			if (button == UIMouseButton.Right)
			{
				return KeyCode.Mouse1;
			}
			if (button == UIMouseButton.Middle)
			{
				return KeyCode.Mouse2;
			}
			if (button == UIMouseButton.Special0)
			{
				return KeyCode.Mouse3;
			}
			if (button == UIMouseButton.Special1)
			{
				return KeyCode.Mouse4;
			}
			if (button == UIMouseButton.Special2)
			{
				return KeyCode.Mouse5;
			}
			if (button == UIMouseButton.Special3)
			{
				return KeyCode.Mouse6;
			}
			return KeyCode.None;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003F24 File Offset: 0x00002124
		private void OnBindingKeyDown(UIComponent comp, UIKeyEventParameter p)
		{
			if (this.m_EditingBinding != null && !this.IsModifierKey(p.keycode))
			{
				p.Use();
				UIView.PopModal();
				KeyCode keycode = p.keycode;
				InputKey value = (p.keycode == KeyCode.Escape) ? this.m_EditingBinding.value : SavedInputKey.Encode(keycode, p.control, p.shift, p.alt);
				if (p.keycode == KeyCode.Backspace)
				{
					value = SavedInputKey.Empty;
				}
				this.m_EditingBinding.value = value;
				(p.source as UITextComponent).text = this.m_EditingBinding.ToLocalizedString("KEYNAME");
				this.m_EditingBinding = null;
				this.m_EditingBindingCategory = string.Empty;
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003FE4 File Offset: 0x000021E4
		private void OnBindingMouseDown(UIComponent comp, UIMouseEventParameter p)
		{
			if (this.m_EditingBinding == null)
			{
				p.Use();
				this.m_EditingBinding = (SavedInputKey)p.source.objectUserData;
				this.m_EditingBindingCategory = p.source.stringUserData;
				UIButton uibutton = p.source as UIButton;
				uibutton.buttonsMask = (UIMouseButton.Left | UIMouseButton.Right | UIMouseButton.Middle | UIMouseButton.Special0 | UIMouseButton.Special1 | UIMouseButton.Special2 | UIMouseButton.Special3);
				uibutton.text = "Press any key";
				p.source.Focus();
				UIView.PushModal(p.source);
				return;
			}
			if (!this.IsUnbindableMouseButton(p.buttons))
			{
				p.Use();
				UIView.PopModal();
				InputKey value = SavedInputKey.Encode(this.ButtonToKeycode(p.buttons), this.IsControlDown(), this.IsShiftDown(), this.IsAltDown());
				this.m_EditingBinding.value = value;
				UIButton uibutton2 = p.source as UIButton;
				uibutton2.text = this.m_EditingBinding.ToLocalizedString("KEYNAME");
				uibutton2.buttonsMask = UIMouseButton.Left;
				this.m_EditingBinding = null;
				this.m_EditingBindingCategory = string.Empty;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000040E4 File Offset: 0x000022E4
		private void RefreshBindableInputs()
		{
			foreach (UIComponent uicomponent in base.component.GetComponentsInChildren<UIComponent>())
			{
				UITextComponent uitextComponent = uicomponent.Find<UITextComponent>("Binding");
				if (uitextComponent != null)
				{
					SavedInputKey savedInputKey = uitextComponent.objectUserData as SavedInputKey;
					if (savedInputKey != null)
					{
						uitextComponent.text = savedInputKey.ToLocalizedString("KEYNAME");
					}
				}
				UILabel uilabel = uicomponent.Find<UILabel>("Name");
				if (uilabel != null)
				{
					uilabel.text = Locale.Get("KEYMAPPING", uilabel.stringUserData);
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004178 File Offset: 0x00002378
		internal InputKey GetDefaultEntry(string entryName)
		{
			FieldInfo field = typeof(DefaultSettings).GetField(entryName, BindingFlags.Static | BindingFlags.Public);
			if (field == null)
			{
				return 0;
			}
			object value = field.GetValue(null);
			if (value is InputKey)
			{
				return (InputKey)value;
			}
			return 0;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000041C0 File Offset: 0x000023C0
		private void RefreshKeyMapping()
		{
			UIComponent[] componentsInChildren = base.component.GetComponentsInChildren<UIComponent>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UITextComponent uitextComponent = componentsInChildren[i].Find<UITextComponent>("Binding");
				SavedInputKey savedInputKey = (SavedInputKey)uitextComponent.objectUserData;
				if (this.m_EditingBinding != savedInputKey)
				{
					uitextComponent.text = savedInputKey.ToLocalizedString("KEYNAME");
				}
			}
		}

		// Token: 0x04000036 RID: 54
		private static readonly string kKeyBindingTemplate = "KeyBindingTemplate";

		// Token: 0x04000037 RID: 55
		private SavedInputKey m_EditingBinding;

		// Token: 0x04000038 RID: 56
		private string m_EditingBindingCategory;

		// Token: 0x04000039 RID: 57
		public static readonly SavedInputKey toggleUI = new SavedInputKey("toggleUI", CameraOperatorMod.SettingsFileName, SavedInputKey.Encode(KeyCode.C, false, false, false), true);

		// Token: 0x0400003A RID: 58
		public static readonly SavedInputKey addPoint = new SavedInputKey("addPoint", CameraOperatorMod.SettingsFileName, SavedInputKey.Encode(KeyCode.KeypadPlus, false, false, false), true);

		// Token: 0x0400003B RID: 59
		public static readonly SavedInputKey removePoint = new SavedInputKey("removePoint", CameraOperatorMod.SettingsFileName, SavedInputKey.Encode(KeyCode.KeypadMinus, false, false, false), true);

		// Token: 0x0400003C RID: 60
		public static readonly SavedInputKey play = new SavedInputKey("play", CameraOperatorMod.SettingsFileName, SavedInputKey.Encode(KeyCode.KeypadEnter, false, false, false), true);

		// Token: 0x0400003D RID: 61
		private int count;
	}
}
