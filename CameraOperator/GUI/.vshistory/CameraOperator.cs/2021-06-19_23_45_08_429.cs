using CameraOperatorMod.GUI;
using CameraOperatorMod.GUI.Panel;
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

	public class CameraOperator : UIPanel
	{
		private HeaderPanel Header { get; set; }
		private TabstripPanel tabStrip;

		private float HeaderHeight => 30f;
		private float TabStripHeight => 28f;

		private Vector2 EditorSize => size - new Vector2(0, Header.height + tabStrip.height);
		private Vector2 EditorPosition => new Vector2(0, tabStrip.relativePosition.y + tabStrip.height);
		
		public static void CreatePanel()
		{
			UIView.GetAView().AddUIComponent(typeof(CameraOperatorButton));
			UIView.GetAView().AddUIComponent(typeof(CameraOperator));
		}

		public void Awake()
		{
			base.Awake();

			clipChildren = true;
			CreateHeader();
			size = new Vector2(DefaultRect.width, DefaultRect.height);
			CreateTabStrip();
			Show();

			CreatePages();
		}

		private void CreatePages()
		{
			CreateTabPage<Path>();
			CreateTabPage<Rotate>();
		}

		private void CreateTabPage<TabPage>()
			where TabPage : BaseTabPage
		{
			var container = tabStrip.tabContainer;
			var page = (container.AddTabPage(typeof(TabPage).Name) as TabPage).AddUIComponent<TabPage>();
			page.size = container.size;
			tabStrip.AddTabButton(typeof(TabPage).Name);
			// tabPages_.Add(typeof(TabPage).Name, page);
		}


		private void CreateHeader()
		{
			Header = AddUIComponent<HeaderPanel>();
			Header.Init(HeaderHeight);
		}

        private void CreateTabStrip()
        {
			tabStrip = AddUIComponent<TabstripPanel>();
			tabStrip.clipChildren = false;
			tabStrip.width = DefaultRect.width;
			tabStrip.height = TabStripHeight;
			tabStrip.color = Helper.RGB(33, 33, 41);
			tabStrip.zOrder = 2;
			tabStrip.backgroundSprite = "WhiteRect";
			tabStrip.padding = Helper.Padding(0, 4, 4);
			tabStrip.relativePosition = new Vector2(0f, HeaderHeight);
			Debug.Log("tabStrip initialized");
			tabStrip.tabPages = AddUIComponent<UITabContainer>();

			var container = tabStrip.tabContainer;
			container.relativePosition = new Vector2(0f, HeaderHeight + TabStripHeight);
			container.width = tabStrip.width;
			container.clipChildren = true;
			container.height = DefaultRect.height - HeaderHeight - TabStripHeight;
			Debug.Log("container initialized");
		}

        protected void SelectTab(int i)
		{
			tabStrip.selectedIndex = i;
			tabStrip.tabPages.components[i].Show();
		}

		public static readonly Rect DefaultRect = new Rect(
			0f, 0f, 500f, 600f
		);



		private Dictionary<string, UIPanel> tabPages_ = new Dictionary<string, UIPanel>();
        public UIPanel TabPage(string name) => tabPages_[name];
    }
}