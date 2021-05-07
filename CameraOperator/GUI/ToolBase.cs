using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    interface ITool : GUI.IConfigurableComponent<GUI.TabbedWindowConfig>
    {
		GUI.TabTemplate[] Tabs { get; }

		void SetVisible(bool flag);
    }
    abstract class ToolBase : MonoBehaviour, ITool
	{

        public virtual void Awake()
        {
			mainButton = UIView.GetAView().AddUIComponent(typeof(UIMainButton)) as UIMainButton;

			mainWindow = UIView.GetAView().AddUIComponent(typeof(UIMainWindow)) as UIMainWindow;
        }
		public virtual void Start()
		{

			mainWindow.clipChildren = true;
			mainWindow.Content.clipChildren = true;

			tabStrip = mainWindow.Content.AddUIComponent<UITabstrip>();
			tabStrip.clipChildren = true;
			tabStrip.width = mainWindow.Content.parent.width;
			tabStrip.height = 28f;
			tabStrip.color = new Color32(20, 20, 40, byte.MaxValue);
			tabStrip.zOrder = 2;
			tabStrip.backgroundSprite = "WhiteRect";
			tabStrip.tabPages = mainWindow.AddUIComponent<UITabContainer>();
			tabStrip.relativePosition = new Vector3(4f, 28f, 20);

			tabStrip.tabPages = mainWindow.Content.AddUIComponent<UITabContainer>();
			var container = tabStrip.tabContainer;
			container.relativePosition = Vector2.zero;
			container.width = tabStrip.width;
			container.clipChildren = true;
			container.height = mainWindow.Content.parent.height - tabStrip.height;

			foreach (var v in Tabs.Select((tab, i) => new { tab, i }))
			{
				{
					var btn = tabStrip.AddTab(v.tab.name, true);
					tabStrip.selectedIndex = v.i; // important for setting current target obj

					btn.tabIndex = v.i; // misc value
					btn.relativePosition = Vector2.zero;
					btn.text = v.tab.name;
					btn.tooltip = v.tab.name;
					btn.height = 25f;
					
					//v.tab.icons.AssignTo(ref btn);

					btn.normalBgSprite = "GenericTab";
					btn.hoveredBgSprite = "GenericTabHovered";
					btn.pressedBgSprite = "GenericTabPressed";
					btn.focusedBgSprite = "GenericTabFocused";

					//btn.spritePadding = Helper.Padding(4, 22);
					btn.width = 100f;
					btn.height = 28f;
					tabStrip.height = Math.Max(tabStrip.height, btn.height);
				}

				var page = container.components[v.i] as UIPanel;

				//page.clipChildren = true;
				tabPages_.Add(v.tab.name, page);

				//Log.Debug($"{page.name}");

				tabPages_.Add(v.tab.name, page);

				//page.relativePosition = Vector2.zero;
				page.isVisible = false;
				page.autoSize = false;
				page.width = tabStrip.width;
				page.height = mainWindow.Content.height - tabStrip.height;

				// auto defocus
				{
					page.canFocus = true;
					page.eventClicked += (c, p) => {
						//Log.Debug($"source: {c}, {p.source}");

						if (p.source == c)
						{
							page.Focus();
						}
					};
				}

				//Log.Debug($"{page.position}, {page.size}");

				mainWindow.Content.eventSizeChanged += (c, size) => {
					page.width = size.x;
					page.height = c.height - tabStrip.height;
				};

				// page.relativePosition = Vector2.zero;
				//page.SetAutoLayout(LayoutDirection.Vertical);

				// Log.Debug($"tc: {tabs_.size} {win_.Content.size} | {page.position} {page.size}");
			}

		}
		protected void SelectTab(int i)
		{
			tabStrip.selectedIndex = i;
			tabStrip.tabPages.components[i].Show();
		}


		private GUI.UIMainButton mainButton;
		protected GUI.UIMainButton Button { get => mainButton; }

		private GUI.UIMainWindow mainWindow;
		protected GUI.UIMainWindow Window { get => mainWindow; }

		public UIPanel TabPage(string name) => tabPages_[name];

		public void SetVisible(bool flag)
		{
			Config.IsVisible = flag;

			if (flag)
			{
				Window.Show();

			}
			else
			{
				Window.Hide();
			}
		}

		public TabTemplate[] Tabs { get; protected set; }
		private Dictionary<string, UIPanel> tabPages_ = new Dictionary<string, UIPanel>();
		private UITabstrip tabStrip;

		private UIPanel content_;
		public UIPanel Content { get => content_; }
        public TabbedWindowConfig Config { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}