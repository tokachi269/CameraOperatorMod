using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class UIUtils
    {
        public static UICheckBox AddCheckBox(ref UIPanel parent, string label, string tooltip, bool initialValue, PropertyChangedEventHandler<bool> onCheckChanged)
        {
            var box = parent.AddUIComponent<UICheckBox>();
            box.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;

            box.label = box.AddUIComponent<UILabel>();
            box.label.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;

            box.label.text = label;

            if (tooltip == null)
            {
                // box.label.tooltip = $"default: {initialValue}";
            }
            else
            {
                box.label.tooltip = tooltip;
            }

            box.label.padding.left = box.label.font.size + 6;

            box.label.relativePosition = new Vector2(0, -(box.label.font.size - 10));
            box.label.FitTo(parent);
            box.height = box.label.height;

            var uncheckedSprite = box.AddUIComponent<UISprite>() as UISprite;
            uncheckedSprite.spriteName = "AchievementCheckedFalse";
            //uncheckedSprite.relativePosition = new Vector2(indentPadding.HasValue ? indentPadding.Value : 0, 2.5f);
            uncheckedSprite.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left;
            uncheckedSprite.width = uncheckedSprite.height = box.label.font.size;

            var checkedSprite = uncheckedSprite.AddUIComponent<UISprite>() as UISprite;
            checkedSprite.spriteName = "AchievementCheckedTrue";
            checkedSprite.relativePosition = Vector2.zero;
            checkedSprite.anchor = uncheckedSprite.anchor;
            checkedSprite.size = uncheckedSprite.size;


            box.checkedBoxObject = checkedSprite;

            box.eventCheckChanged += onCheckChanged;
            box.isChecked = initialValue;
            // box.isChecked = initialValue;
            //if (initialValue) box.SimulateClick();
            return box;
        }

    }
}
