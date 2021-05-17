using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.GUI
{
    class Path
    {

        public static void Setup(ref UIPanel page)
        {
            var pane = page.AddUIComponent<UIPanel>();
            pane.width = pane.parent.width - page.padding.horizontal;
            //pane.padding = Helper.Padding(4, 12, 4, 0);
           // pane.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
            pane.autoFitChildrenVertically = true;

        }
    }
}
