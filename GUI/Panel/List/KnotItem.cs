using ColossalFramework.UI;
using System;
using CameraOperator.Tool;

namespace CameraOperatorMod.GUI
{
    public class KnotItem : UIPanel, IUIFastListRow
    {
        static float ItemHeight = 20f;
        
        UILabel IndexLabel;

        bool initialized;

        public KnotItem()
        {
            width = CameraOperator.DefaultRect.width / 3;
            height = ItemHeight;
            isVisible = true;
            isInteractive = true;
            backgroundSprite = "TextFieldPanel";

            tooltipBox.GetComponent<UILabel>().textAlignment = UIHorizontalAlignment.Left;
            //GenerateTooltip(Prefab);
            //eventTooltipEnter += TreeItem_eventTooltipEnter;
            //eventMouseLeave += TreeItem_eventMouseLeave;
            IndexLabel = AddUIComponent<UILabel>();
            IndexLabel.autoSize = false;
            IndexLabel.width = 255.0f;
        }

        public void Initialize() => Initialize(null, 0);
        public void Initialize(CameraConfig cp, int index)
        {
            IndexLabel.text = index.ToString();

        }

        internal void InitDisplay(int index, bool pos, bool rot, bool fov, bool zoom)
        {
            IndexLabel.text = index.ToString();
            if (pos)
            {
               // AddUIComponent<UISprite>();
            }

            initialized = true;
        }

        public void Deselect(bool isRowOdd)
        {
            throw new NotImplementedException();
        }

        public void Display(object data, bool isRowOdd)
        {
            if (!initialized) Initialize();
        }

        public void Select(bool isRowOdd)
        {
            throw new NotImplementedException();
        }

    }
}
