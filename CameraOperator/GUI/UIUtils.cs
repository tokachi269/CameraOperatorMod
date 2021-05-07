using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TokachiCinematicCameraMod.GUI
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
        public static UIDropDown AddDropDown(ref UIPanel parent, string name, string[] options, string initialValue, PropertyChangedEventHandler<int> onSelectedIndexChanged, UIFont font = null)
        {
            if (font == null)
            {
                font = FontStore.Get(11);
            }

            var panel = parent.AttachUIComponent(UITemplateManager.GetAsGameObject("OptionsDropdownTemplate")) as UIPanel;
            panel.clipChildren = false;
            panel.SetAutoLayout(LayoutDirection.Horizontal);
            panel.autoFitChildrenVertically = true;

            var label = panel.Find<UILabel>("Label");
            label.text = name;
            label.textScale = 1;
            label.font = font;
            label.textColor = RGB(160, 160, 160);
            label.padding = Padding(0, 14, 0, 18);

            var dd = panel.Find<UIDropDown>("Dropdown");
            dd.font = FontStore.Get(11);
            dd.textScale = 1;

            dd.width = 98;
            dd.name = name;
            dd.autoSize = false;
            dd.height = dd.font.size + dd.spritePadding.vertical + dd.textFieldPadding.vertical + dd.outlineSize * 2;
            //dd.autoListWidth = false;
            //dd.itemHeight = font.size;
            //dd.listHeight = font.size;

            dd.listPosition = UIDropDown.PopupListPosition.Below;
            dd.textFieldPadding = Padding(2, 0, 2, 8);
            dd.spritePadding = Padding(5, 8, 3, 8);
            dd.listPadding = Padding(0, 0);
            dd.itemPadding = Padding(3, 0, 0, 6);

            //dd.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;

            dd.items = options;
            dd.selectedIndex = 0;

            //dd.eventDropdownOpen += (UIDropDown self, UIListBox popup, ref bool overridden) => {
            //    Log.Debug($"popup: {popup.position}, {popup.size}");
            //    Log.Debug($"popup.p: {popup.parent}");
            //    overridden = true;
            //};
            dd.eventDropdownClose += (UIDropDown self, UIListBox popup, ref bool overridden) => {
                self.Unfocus();
            };

            dd.eventSelectedIndexChanged += onSelectedIndexChanged;
            dd.selectedValue = initialValue;
            return dd;
        }
    }
}
