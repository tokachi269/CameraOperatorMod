using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI.Panel
{
    class TabstripPanel: UITabstrip
    {
		int defaultWidth = 80;
		public UIButton AddTabImp(string text)
		{
			UIButton btn = base.AddUIComponent<UIButton>();
			btn.name = text;
			btn.atlas = this.atlas;

			btn.group = this;

			if (this.tabPages != null)
			{
				// this.tabPages.AddTabPage(text);
			}
			this.ArrangeTabs();
			this.Invalidate();
			return btn;
		}

		private bool ArrangeInProgress { get; set; }
		public void ArrangeTabs()
		{
			var tabsArray = tabs.Where(t => t.isVisible).ToArray();
			if (!tabsArray.Any() || ArrangeInProgress)
				return;

			ArrangeInProgress = true;

			foreach (var tab in tabsArray)
			{
				//tab.autoSize = true;
				//tab.autoSize = false;
			}

			//var tabRows = FillTabRows(tabsArray);
			//ArrangeTabRows(tabRows);
			//PlaceTabRows(tabRows);

			FitChildrenVertically();

			ArrangeInProgress = false;
		}

        public UIButton AddTab(string name)
        {
			// ColossalFramework.UI.UITabstripはAddTabしたときにpageも生成してしまうのでtabのみ生成すよう再定義

			var btn = AddTabImp(name);

			btn.width = 80f;
			btn.relativePosition = new Vector2(0f, -height);
			btn.textPadding = Helper.Padding(3, 1, 2);
			btn.text = name;
			btn.tooltip = name;
			btn.height = height - 3f;

			btn.normalBgSprite = "GenericTab";
			btn.hoveredBgSprite = "GenericTabHovered";
			btn.pressedBgSprite = "GenericTabPressed";
			btn.focusedBgSprite = "GenericTabFocused";

			btn.width = width / tabCount;
			btn.height = 28f;
			return btn;
		}
    }
}
