using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class TabstripPanel: UITabstrip
    {
		float defaultWidth = 80;
		float defaultHeight = 28;
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

		//tabのみ追加する(ColossalFramework.UI.UITabstrip.AddTab()はpageも同時に生成するため)
		public UIButton AddTabOnly(string name)
        {

			var btn = AddTabImp(name);
			btn.autoSize = false;
			btn.width = 80f;
			btn.relativePosition = new Vector2(0f, -(defaultHeight + 2));
			btn.textPadding = Helper.Padding(4, 1, 2);
			btn.text = name;
			btn.tooltip = name;
			btn.height = height - 3f;
			btn.normalBgSprite = "GenericTab";
			btn.hoveredBgSprite = "GenericTabHovered";
			btn.pressedBgSprite = "GenericTab";
			btn.focusedBgSprite = "GenericTab";
			btn.color = Helper.RGB(158, 158, 158);
			btn.focusedColor = Helper.RGB(246, 246, 246);
			btn.hoveredColor = Helper.RGB(158, 158, 158);
			btn.height = defaultHeight - 2f;
			return btn;
		}
    }
}
