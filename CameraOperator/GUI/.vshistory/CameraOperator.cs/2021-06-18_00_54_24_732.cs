﻿using CameraOperatorMod.GUI;
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

	public class CameraOperatorToolBase : UIPanel
    {
		private void CreateEditor<TabPage>() where TabPage : BaseTabPage
		{
			var tabPage = AddUIComponent<TabPage>();
			tabPage.Active = false;
			//tabPage.Init(this);
			tabStrip.AddTab(tabPage.Name);
		}
		public static void CreatePanel()
		{
			UIView.GetAView().AddUIComponent(typeof(CameraOperatorButton));
			UIView.GetAView().AddUIComponent(typeof(CameraOperatorToolBase));
		}

		private void CreatePages()
        {
			CreateEditor<Path>();
		}

        public void Awake()
        {
			base.Awake();
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

			size = new Vector2(DefaultRect.width, DefaultRect.height);

			clipChildren = true;
			Content.clipChildren = true;

			{
				tabStrip = Content.AddUIComponent<UITabstrip>();
				tabStrip.clipChildren = true;
				tabStrip.width = Content.parent.width - 10;
				tabStrip.height = 28f;
				tabStrip.color = Helper.RGB(33, 33, 41);
				tabStrip.zOrder = 2;
				tabStrip.backgroundSprite = "WhiteRect";
				tabStrip.padding = Helper.Padding(28, 4, 4);

				tabStrip.tabPages = Content.AddUIComponent<UITabContainer>();

				var container = tabStrip.tabContainer;
				container.relativePosition = Vector2.zero;
				container.width = tabStrip.width;
				container.clipChildren = true;
				container.height = Content.parent.height - tabStrip.height;

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
					page.height = Content.height - tabStrip.height;

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

					Content.eventSizeChanged += (c, size) => {
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
			//{
			//	var page = TabPage("Path");
			//	Path.Setup(ref page);
			//}
			//
			//{
			//	var page = TabPage("Rotate");
			//	Rotate.Setup(ref page);
			//}

			SelectTab(Config.SelectedTabIndex);
			// var page = TabPage("Path");
			// Window.AddUIComponent<UIPanel>();
			Content.clipChildren = true;
			clipChildren = false;
			Show();

			CreatePages();
        }

		protected void SelectTab(int i)
		{
			tabStrip.selectedIndex = i;
			tabStrip.tabPages.components[i].Show();
		}

		public static readonly Rect DefaultRect = new Rect(
			0f, 0f, 500f, 600f
		);

		public void SetVisible(bool flag)
		{
			Config.IsVisible = flag;

			if (flag)
			{
				Show();

			}
			else
			{
				Hide();
			}
		}
		private UITabstrip tabStrip;
		private TabTemplate[] Tabs { get;  set; }

		private Dictionary<string, UIPanel> tabPages_ = new Dictionary<string, UIPanel>();
		public UIPanel TabPage(string name) => tabPages_[name];

		private UIPanel content_;
		public UIPanel Content { get => content_; }
        public TabbedWindowConfig Config { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}