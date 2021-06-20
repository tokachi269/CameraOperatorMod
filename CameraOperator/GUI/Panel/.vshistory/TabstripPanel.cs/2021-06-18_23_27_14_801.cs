using CameraOperatorMod.GUI;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI.Panel
{
    class TabstripPanel: UITabstrip
    {
        public void AddTab(BaseTabPage tabPage)
        {
            var tab = TabButton(tabPage.TabName, true);
            tab.BaseTabPage = editor;
        }

        private void TabButton(String name, bool fillText)
        {
			var btn = tabStrip.AddTab(page.name, true);
			//tabStrip.selectedIndex = tabStrip.tabCount; // important for setting current target obj
			btn.relativePosition = new Vector2(0f, -TabStripHeight);
			btn.text = page.TabName;
			btn.tooltip = page.TabName;
			btn.height = TabStripHeight - 3f;

			btn.normalBgSprite = "GenericTab";
			btn.hoveredBgSprite = "GenericTabHovered";
			btn.pressedBgSprite = "GenericTabPressed";
			btn.focusedBgSprite = "GenericTabFocused";

			btn.width = tabStrip.width / tabStrip.tabCount;
			btn.height = 28f;
		}
    }
}
