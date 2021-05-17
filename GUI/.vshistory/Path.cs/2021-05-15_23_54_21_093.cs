using ColossalFramework.UI;
using ForestBrush.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TokachiCinematicCameraMod.GUI
{
    public static class Path
    {

        public static void Setup(ref UIPanel page)
        {
            var pane = page.AddUIComponent<UIPanel>();
            pane.width = pane.parent.width - page.padding.horizontal;
            //pane.padding = Helper.Padding(4, 12, 4, 0);
           // pane.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
            pane.autoFitChildrenVertically = true;

            UIFastList myFastList = UIFastList.Create<MyCustomRow>(this);
            myFastList.size = new Vector2(200f, 300f);
            myFastList.rowHeight = 40f;
            myFastList.rowData = myDataList;
        }
    }
}
