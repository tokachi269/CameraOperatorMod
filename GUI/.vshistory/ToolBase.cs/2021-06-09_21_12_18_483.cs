using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    internal interface ITool : GUI.IConfigurableComponent<GUI.TabbedWindowConfig>
    {
		GUI.TabTemplate[] Tabs { get; }

		void SetVisible(bool flag);
    }

    internal abstract class ToolBase : MonoBehaviour, ITool
    {
		private void CreateEditor<TabPage>() where TabPage : BaseTabPage
		{
			var tabPage = AddUIComponent<TabPage>();
			tabPage.Active = false;
			tabPage.Init(this);
			TabStrip.AddTab(tabPage);

			Editors.Add(tabPage);
		}
		public virtual void Awake()
        {
			Tabs = new[] {
			new TabTemplate() {
				name = "Path" },
			new TabTemplate() {
				name = "Rotate" },
			new TabTemplate() {
				name = "Aerial" },
			new TabTemplate() {
				name = "Fixed" }
			};
			Button = UIView.GetAView().AddUIComponent(typeof(CameraOperatorButton)) as CameraOperatorButton;
            Window = UIView.GetAView().AddUIComponent(typeof(CameraOperator)) as CameraOperator;
        }

        public virtual void Start()
		{
			Window.clipChildren = true;
			Window.Content.clipChildren = true;

			{
				tabStrip = Window.Content.AddUIComponent<UITabstrip>();
				tabStrip.clipChildren = true;
				tabStrip.width = Window.Content.parent.width - 10;
				tabStrip.height = 28f;
				tabStrip.color = Helper.RGB(33, 33, 41);
				tabStrip.zOrder = 2;
				tabStrip.backgroundSprite = "WhiteRect";
				tabStrip.padding = Helper.Padding(28, 4, 4);

				tabStrip.tabPages = Window.Content.AddUIComponent<UITabContainer>();

				var container = tabStrip.tabContainer;
				container.relativePosition = Vector2.zero;
				container.width = tabStrip.width;
				container.clipChildren = true;
				container.height = Window.Content.parent.height - tabStrip.height;

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

						// v.tab.icons.AssignTo(ref btn);
						btn.normalBgSprite = "GenericTab";
						btn.hoveredBgSprite = "GenericTabHovered";
						btn.pressedBgSprite = "GenericTabPressed";
						btn.focusedBgSprite = "GenericTabFocused";

						//btn.spritePadding = Helper.Padding(4, 22);
						btn.width = tabStrip.width / Tabs.Length;
						btn.height = 28f;
						tabStrip.height = Math.Max(tabStrip.height, btn.height);
					}

					var page = container.components[v.i] as UIPanel;

					//page.clipChildren = true;
					tabPages_.Add(v.tab.name, page);

					page.isVisible = false;
					page.autoSize = false;
					page.width = tabStrip.width;
					page.height = Window.Content.height - tabStrip.height;

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

					Window.Content.eventSizeChanged += (c, size) => {
						page.width = size.x;
						page.height = c.height - tabStrip.height;
					};
					// page.relativePosition = Vector2.zero;
					//page.SetAutoLayout(LayoutDirection.Vertical);
					page.SetAutoLayout(LayoutDirection.Vertical);
					// Log.Debug($"tc: {tabs_.size} {win_.Content.size} | {page.position} {page.size}");
				}
				//tabStrip.eventSelectedIndexChanged += (c, i) => {
				//	//Log.Info($"tab: {c.tabIndex}, {i}");
				//	Config.SelectedTabIndex = i;
				//};
			}
		}

		protected void SelectTab(int i)
		{
			tabStrip.selectedIndex = i;
			tabStrip.tabPages.components[i].Show();
		}

        protected CameraOperatorButton Button { get; private set; }

        protected CameraOperator Window { get; private set; }

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
		private UITabstrip tabStrip;
		public TabTemplate[] Tabs { get; protected set; }

		private Dictionary<string, UIPanel> tabPages_ = new Dictionary<string, UIPanel>();
		public UIPanel TabPage(string name) => tabPages_[name];


		private UIPanel content_;
		public UIPanel Content { get => content_; }
        public TabbedWindowConfig Config { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}