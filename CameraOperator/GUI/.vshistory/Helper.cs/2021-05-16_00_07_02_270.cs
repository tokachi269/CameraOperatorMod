﻿using ColossalFramework.UI;
using UnityEngine;
using System;

namespace CameraOperatorMod.GUI
{
    public static class Helper
    {
        public static RectOffset ZeroOffset {
            get => new RectOffset(0, 0, 0, 0);
        }

        public static Vector2 ScreenResolution {
            get => UIView.GetAView().GetScreenResolution();
        }

        public static Rect ScreenRectAsScreen {
            get {
                //Log.Debug($"{v.GetScreenResolution()}, {v.scale}, {v.ratio}, {v.inputScale}");

                var res = ScreenResolution;
                return new Rect(
                    x: 0, y: 0, width: res.x, height: res.y
                );
            }
        }

        public static Rect ScreenRectAsUI {
            get => ScreenToUI(ScreenRectAsScreen);
        }

        // UI coordinates = same axis as Screen, center point at "center"
        public static Rect ScreenToUI(Rect r)
        {
            var res = ScreenResolution;
            return new Rect(
                x: r.x - res.x / 2,
                y: r.y - res.y / 2,
                width: r.width,
                height: r.height
            );
        }

        public static Color32 RGB(byte r, byte g, byte b)
        {
            return new Color32(r, g, b, 255);
        }
        public static Color32 RGBA(byte r, byte g, byte b, byte a)
        {
            return new Color32(r, g, b, a);
        }

        // CSS-like padding specifiers
        public static RectOffset Padding(int top, int? right = null, int? bottom = null, int? left = null)
        {
            if (!right.HasValue) {
                return new RectOffset(top: top, bottom: top, left: 0, right: 0);
            }
            if (!bottom.HasValue) {
                return new RectOffset(top: top, bottom: top, left: right.Value, right: right.Value);
            }
            if (!left.HasValue) {
                return new RectOffset(top: top, right: right.Value, bottom: bottom.Value, left: 0);
            }
            return new RectOffset(top: top, right: right.Value, bottom: bottom.Value, left: left.Value);
        }

        public static UILabel AddLabel(ref UIPanel parent, string label, string tooltip = "", UIFont font = null, RectOffset padding = null, Color32? color = null, string bullet = null)
        {
            var obj = parent.AddUIComponent<UILabel>();
            obj.text = label;
            obj.tooltip = tooltip;
            if (color.HasValue) {
                obj.textColor = color.Value;
            }

            var bulletSize = obj.font.size + 4;
            obj.padding.left += bulletSize + 3;

            if (bullet != null) {
                obj.padding.left += 3;

                var sp = obj.AddUIComponent<UISprite>();
                sp.spriteName = bullet;
                sp.width = sp.height = bulletSize;
                sp.relativePosition = new Vector2(2, 0);
            }
            return obj;
        }

        public static UIPanel AddIconLabel(ref UIPanel parent, string icon, string label, string tooltip = "", UIFont font = null, Color32? color = null, float? wrapperWidth = null, bool isInverted = false)
        {
            var wrapper = parent.AddUIComponent<UIPanel>();
            wrapper.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;
            wrapper.autoSize = true;
            //wrapper.SetAutoLayout(LayoutDirection.Horizontal);
            if (wrapperWidth.HasValue) {
                wrapper.width = wrapperWidth.Value;
            }

           // var iconObj = Helper.AddIcon(ref wrapper, icon, 16);

            var labelObj = wrapper.AddUIComponent<UILabel>();
            labelObj.font = font;
            labelObj.text = label;
            labelObj.tooltip = tooltip;
            if (color.HasValue) labelObj.textColor = color.Value;

            //if (isInverted) {
            //    //wrapper.autoLayoutStart = LayoutStart.TopRight;
            //    //iconObj.relativePosition = new Vector2(wrapper.width, 0);
            //    //labelObj.relativePosition = new Vector2(wrapper.width - iconObj.width, 0);
            //    //labelObj.textAlignment = UIHorizontalAlignment.Right;
            //    iconObj.relativePosition = new Vector2(wrapper.width - iconObj.width, 0);
            //    labelObj.relativePosition = new Vector2(iconObj.relativePosition.x - labelObj.width - 4, 0);
            //
            //} else {
            //    iconObj.relativePosition = Vector2.zero;
            //    labelObj.relativePosition = new Vector2(iconObj.width, 0);
            //    labelObj.padding.left = 4;
            //}

            return wrapper;
        }

        public static UICheckBox AddCheckBox(ref UIPanel parent, string label, string tooltip, bool initialValue, PropertyChangedEventHandler<bool> onCheckChanged, UIFont font = null, int? indentPadding = null)
        {
            var box = parent.AddUIComponent<UICheckBox>();
            box.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;


            box.label = box.AddUIComponent<UILabel>();
            box.label.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;

            box.label.text = label;

            if (tooltip == null) {
                // box.label.tooltip = $"default: {initialValue}";

            } else {
                box.label.tooltip = tooltip;
            }

            if (font != null) {
                box.label.font = font;
            }
            box.label.padding.left = box.label.font.size + 6;
            if (indentPadding.HasValue) {
                box.label.padding.left += indentPadding.Value;
            }

            box.label.relativePosition = new Vector2(0, -(box.label.font.size - 10));
            box.label.FitTo(parent);
            box.height = box.label.height;


            var uncheckedSprite = box.AddUIComponent<UISprite>() as UISprite;
            uncheckedSprite.spriteName = "AchievementCheckedFalse";
            uncheckedSprite.relativePosition = new Vector2(indentPadding.HasValue ? indentPadding.Value : 0, 2.5f);
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

        public static void DeepDestroy(UIComponent component)
        {
            if (component == null) return;
            var children = component.GetComponentsInChildren<UIComponent>();

            if (children != null && children.Length > 0) {
                for (int i = 0; i < children.Length; ++i) {
                    if (children[i].parent == component) {
                        DeepDestroy(children[i]);
                    }
                }
            }
            UnityEngine.Object.Destroy(component);
            component = null;
        }
    }
}
