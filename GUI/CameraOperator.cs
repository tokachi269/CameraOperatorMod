using System.Collections.Generic;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class CameraOperator : UIPanel
	{
		private HeaderPanel Header { get; set; }
		private TabstripPanel tabStrip;

		private float HeaderHeight => 30f;
		private float TabStripHeight => 28f;
		public static Vector2 DefaultFormSize => new Vector2(70, 22);

		private Vector2 EditorSize => size - new Vector2(0, Header.height + tabStrip.height);
		private Vector2 EditorPosition => new Vector2(0, tabStrip.relativePosition.y + tabStrip.height);
		public List<BaseTabPage> Editors { get; } = new List<BaseTabPage>();

		public static void CreatePanel()
		{
			Debug.Log($"Create button");
			UIView.GetAView().AddUIComponent(typeof(CameraOperatorButton));
			Debug.Log($"button Created");

			Debug.Log($"Create panel");
			UIView.GetAView().AddUIComponent(typeof(CameraOperator));
			Debug.Log($"panel Created");
		}

		public override void Awake()
		{
			base.Awake();

			clipChildren = true;
			CreateHeader();
			size = new Vector2(DefaultRect.width, DefaultRect.height);
            color = Helper.RGBA(255, 255, 255, 215);
			CreateTabStrip();
			CreatePages();
			Show();
			
		}

		private void CreatePages()
		{
			CreateTabPage<PathPage>();
			CreateTabPage<RotatePage>();
			CreateTabPage<UtilsPage>();
			CreateTabPage<AboutPage>();
		}

		private void CreateTabPage<TabPage>()
			where TabPage : BaseTabPage
        {
			//	{ 
			//		var page = tabStrip.tabContainer.AddTabPage(typeof(TabPage).Name);
			//		Debug.Log(typeof(TabPage).Name + $"Tabpage Created");
			//
			//		page.size = tabStrip.tabContainer.size;
			//		page.AddUIComponent<TabPage>();
			//		tabStrip.AddTabButton(typeof(TabPage).Name);
			//		Debug.Log(typeof(TabPage).Name + $"TabButton Created");
			//	}
			//var editor = AddUIComponent<TabPage>();
			//editor.Active = false;
			//editor.Init(this);

			var page = tabStrip.tabContainer.AddUIComponent<TabPage>();
			page.name = page.TabMode.ToString();
			var tab = tabStrip.AddTabOnly(page.name);

			int index = tabStrip.tabCount - 1;
			tab.tabIndex = tabStrip.tabCount;
			page.tabIndex = index;
			tabStrip.selectedIndex = index;//setting current target obj

			//tabStrip.tabContainer.Find<TabPage>("Tab " + (tabStrip.tabContainer.childCount + 1) + " - " + typeof(TabPage).Name).AddUIComponent<TabPage>();
			//var page = tabStrip.tabPage(tab.tabIndex - 1).AddUIComponent<TabPage>();
			//page.size = tabStrip.tabContainer.size;
			//Editors.Add(editor);
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
			tabStrip.padding = Helper.Padding(3, 4, 4);
			tabStrip.relativePosition = new Vector2(0f, HeaderHeight);
			Debug.Log("tabStrip initialized");
			tabStrip.tabPages = AddUIComponent<UITabContainer>();

			// var container = tabStrip.tabPages;
			tabStrip.tabPages.relativePosition = new Vector2(0f, HeaderHeight + TabStripHeight);
			tabStrip.tabPages.width = tabStrip.width;
			tabStrip.tabPages.clipChildren = true;
			tabStrip.tabPages.height = DefaultRect.height - HeaderHeight - TabStripHeight;
			Debug.Log("container initialized");
		}

       public void Toggle()
        {
            isVisible = !isVisible;
        }

		protected void SelectTab(int i)
		{
			tabStrip.selectedIndex = i;
			tabStrip.tabPages.components[i].Show();
		}

		public static readonly Rect DefaultRect = new Rect(
			0f, 0f, 500f, 600f
		);

    }
}