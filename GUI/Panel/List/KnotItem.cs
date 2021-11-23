using ColossalFramework.UI;
using System;
using CamOpr.Tool;
using UnityEngine;

namespace CamOpr.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        private static float ItemHeight = 20f;
        
        private UILabel IndexLabel;
        private bool initialized;
        CameraConfig cp;

        public KnotItem()
        {
            width = CameraOperator.DefaultRect.width / 3;
            height = ItemHeight;
            isVisible = true;
            isInteractive = true;
            backgroundSprite = "ButtonWhiteHovered";
            color = Helper.GrayScale(220);
            tooltipBox.GetComponent<UILabel>().textAlignment = UIHorizontalAlignment.Left;
            //GenerateTooltip(Prefab);
            //eventTooltipEnter += TreeItem_eventTooltipEnter;
            //eventMouseLeave += TreeItem_eventMouseLeave;
            IndexLabel = AddUIComponent<UILabel>();
            IndexLabel.autoSize = false;
            IndexLabel.size = new Vector2(30f, 20f);
            IndexLabel.textAlignment = UIHorizontalAlignment.Right;
            IndexLabel.padding = Helper.Padding(top: 3);
            autoLayout = true;
        }

        public void Initialize() => Initialize(null);
        public void Initialize(CameraConfig cp)
        {
            if (!(cp is null))
            {
                if (cp.ListIndex >= 0)
                {
                    IndexLabel.text = cp.ListIndex.ToString().PadLeft(3);
                }
            }

        }

        public void Deselect(bool isRowOdd)
        {
            color = Helper.GrayScale(210);
            if (isRowOdd)
            {
                color = Helper.GrayScale(200);
            }
            else
            {
                color = Helper.GrayScale(236);
            }
        }

        public void Display(object data, bool isRowOdd)
        {
            cp = data as CameraConfig;

            if (!initialized) Initialize();
            if (!(cp is null))
            {
                if (cp.ListIndex >= 0)
                {
                    IndexLabel.text = cp.ListIndex.ToString().PadLeft(3);
                }
            }

            if (isRowOdd)
            {
                color = Helper.GrayScale(236);
            }
        }

        public void Select(bool isRowOdd)
        {
            color = Helper.GrayScale(230);
        }
    }
}
