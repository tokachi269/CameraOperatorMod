﻿using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
	struct TabTemplate
	{
		public string name;
	}
	internal interface ITool : GUI.IConfigurableComponent<GUI.TabbedWindowConfig>
    {
		GUI.TabTemplate[] Tabs { get; }

		void SetVisible(bool flag);
    }

	public class CameraOperatorToolBase : CameraOperator
	{

		private float HeaderHeight => 28f;
		private float TabStripHeight => 28f;

		private Vector2 EditorSize => size - new Vector2(0, Header.height + tabStrip.height);
		private Vector2 EditorPosition => new Vector2(0, tabStrip.relativePosition.y + tabStrip.height);

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
		private void CreateHeader()
		{
			Header = AddUIComponent<HeaderPanel>();
			Header.Init(HeaderHeight);

		}
		public void Awake()
        {
			base.Awake();

			CreateHeader();

			var Tabs = new[] {
			new { name = "Path" },
			new { name = "Rotate" },
			new { name = "Aerial" },
			new { name = "Fixed" }
			};

			size = new Vector2(DefaultRect.width, DefaultRect.height);

			clipChildren = true;

			{
				tabStrip = AddUIComponent<UITabstrip>();
				tabStrip.clipChildren = true;
				tabStrip.width = DefaultRect.width - 10;
				tabStrip.height = TabStripHeight;
				tabStrip.color = Helper.RGB(33, 33, 41);
				tabStrip.zOrder = 2;
				tabStrip.backgroundSprite = "WhiteRect";
				tabStrip.padding = Helper.Padding(28, 4, 4);
				Debug.Log("tabStrip initialized");
				tabStrip.tabPages = AddUIComponent<UITabContainer>();

				var container = tabStrip.tabContainer;
				container.relativePosition = Vector2.zero;
				container.width = tabStrip.width;
				container.clipChildren = true;
				container.height = DefaultRect.height - HeaderHeight - TabStripHeight;
				Debug.Log("container initialized");

				foreach (var v in Tabs.Select((tab, i) => new { tab, i }))
				{
					{
						var btn = tabStrip.AddTab(v.tab.name, true);
						tabStrip.selectedIndex = v.i; // important for setting current target obj

						btn.tabIndex = v.i; // misc value
						btn.relativePosition = Vector2.zero;
						btn.text = v.tab.name;
						btn.tooltip = v.tab.name;
						btn.height = TabStripHeight - 3f;

						btn.normalBgSprite = "GenericTab";
						btn.hoveredBgSprite = "GenericTabHovered";
						btn.pressedBgSprite = "GenericTabPressed";
						btn.focusedBgSprite = "GenericTabFocused";

						btn.width = tabStrip.width / Tabs.Length;
						btn.height = 28f;
						tabStrip.height = Math.Max(tabStrip.height, btn.height);
					}

					var page = container.components[v.i] as UIPanel;

					page.clipChildren = true;
					tabPages_.Add(v.tab.name, page);

					page.isVisible = false;
					page.autoSize = false;
					page.width = tabStrip.width;
					page.height = height - tabStrip.height;

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

					eventSizeChanged += (c, size) => {
						page.width = size.x;
						page.height = c.height - tabStrip.height;
					};

					page.SetAutoLayout(LayoutDirection.Vertical);
					Debug.Log($"tc: {tabStrip.size} | {page.position} {page.size}");
				}
				//tabStrip.eventSelectedIndexChanged += (c, i) => {
				//	//Log.Info($"tab: {c.tabIndex}, {i}");
				//	Config.SelectedTabIndex = i;
				//};
			}

			//SelectTab(Config.SelectedTabIndex);

			clipChildren = true;
			Show();

			// CreatePages();
        }

		protected void SelectTab(int i)
		{
			tabStrip.selectedIndex = i;
			tabStrip.tabPages.components[i].Show();
		}

		public static readonly Rect DefaultRect = new Rect(
			0f, 0f, 500f, 600f
		);

		private HeaderPanel Header { get; set; }

		private UITabstrip tabStrip;

		private Dictionary<string, UIPanel> tabPages_ = new Dictionary<string, UIPanel>();


        public UIPanel TabPage(string name) => tabPages_[name];

    }
}