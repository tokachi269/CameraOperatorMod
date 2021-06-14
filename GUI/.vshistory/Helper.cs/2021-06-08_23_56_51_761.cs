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

        public static UILabel AddLabel(ref UIPanel parent, string label, string tooltip = "",  RectOffset padding = null, Color32? color = null, string bullet = null)
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

        public static void SetAutoLayout(
            this UIPanel c,
            LayoutDirection direction,
            RectOffset padding = null,
            LayoutStart start = LayoutStart.TopLeft
        ) 
        {
            c.autoLayout = true;
            c.autoLayoutDirection = direction;
            c.autoLayoutStart = start;
            c.autoLayoutPadding = padding ?? Helper.ZeroOffset;
        }

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

        public static SliderPane AddSliderPane<T>(ref UIPanel parent, SliderOption<T> opts, UIFont font = null)
        {
            var pane = new SliderPane()
            {
                wrapper = parent.AddUIComponent<UIPanel>(),
            };

            pane.wrapper.padding.top = 4;

            pane.wrapper.width = pane.wrapper.parent.width - parent.padding.horizontal;
            pane.wrapper.autoSize = false;
            //pane.SetAutoLayout(LayoutDirection.Horizontal);
            //pane.backgroundSprite = "Menubar";
            pane.wrapper.pivot = UIPivotPoint.MiddleLeft;

            pane.slider = pane.wrapper.AddUIComponent<UISlider>();
            pane.slider.autoSize = true;
            pane.slider.relativePosition = new Vector2(font.size * 1.5f, 0);
            pane.slider.pivot = UIPivotPoint.MiddleLeft;
            pane.slider.anchor = UIAnchorStyle.Left | UIAnchorStyle.CenterVertical;

            pane.slider.minValue = opts.minValue;
            pane.slider.maxValue = opts.maxValue;
            pane.slider.stepSize = opts.stepSize;
            pane.slider.scrollWheelAmount = pane.slider.stepSize * 2 + float.Epsilon;
            pane.slider.backgroundSprite = "BudgetSlider";

            {
                var thumb = pane.slider.AddUIComponent<UISprite>();
                pane.slider.thumbObject = thumb;
                thumb.spriteName = "SliderBudget";
                pane.slider.height = thumb.height + 8;
                pane.slider.thumbOffset = new Vector2(1, 1);
            }
            pane.slider.width = pane.wrapper.width - 24;
            pane.wrapper.height = pane.slider.height + 10;

            pane.slider.eventValueChanged += (c, value) => {
                if (pane.field != null)
                {
                    pane.field.text = value.ToString();
                }
                opts.onValueChanged.Invoke(c, value);
            };

            if (opts.hasField)
            {
                pane.slider.width -= 48;

                pane.field = pane.wrapper.AddUIComponent<UITextField>();

                pane.field.autoSize = false;
                pane.field.width = parent.width - pane.slider.width - parent.padding.horizontal - 20 - 6;
                pane.field.relativePosition = new Vector2(pane.field.parent.width - pane.field.width, 0);
                pane.field.anchor = UIAnchorStyle.CenterVertical | UIAnchorStyle.Right;
                pane.field.height -= 4;

                pane.field.readOnly = false;
                pane.field.builtinKeyNavigation = true;

                pane.field.numericalOnly = true;
                pane.field.allowFloats = true;

                pane.field.canFocus = true;
                pane.field.selectOnFocus = true;
                pane.field.submitOnFocusLost = true;

                pane.field.cursorBlinkTime = 0.5f;
                pane.field.cursorWidth = 1;
                pane.field.selectionSprite = "EmptySprite";
                pane.field.normalBgSprite = "TextFieldPanel";
                //field.hoveredBgSprite = "TextFieldPanelHovered";
                pane.field.focusedBgSprite = "TextFieldPanel";

                pane.field.clipChildren = true;

                pane.field.colorizeSprites = true;
                pane.field.color = Helper.RGB(30, 30, 30);
                pane.field.textColor = Helper.RGB(250, 250, 250);
                //pane.field.font = FontStore.Get(11);
                pane.field.horizontalAlignment = UIHorizontalAlignment.Left;
                pane.field.padding = Helper.Padding(0, 6);

                //field.padding.top -= 5;

                //Log.Debug($"Page: {page.position}, {page.size}");
                //Log.Debug($"Panel: {panel.position}, {panel.size}");
                //Log.Debug($"Slider: {slider.position}, {slider.size}");
                //Log.Debug($"Field: {field.position}, {field.size}");

                pane.field.eventTextSubmitted += (c, text) => {
                    if (text == "") return;
                    try
                    {
                        pane.slider.value = float.Parse(text);

                    }
                    catch (Exception e)
                    {
                        //Log.Error($"failed to set new value \"{text}\": {e}");
                        pane.field.text = "";
                    }
                };
            } // hasField

            pane.slider.value = opts.initialValue;
            //pane.wrapper.height = pane.slider.height + (pane.field?.height).GetValueOrDefault(0);
            return pane;
        }

        public static UIButton AddButton(ref UIPanel parent, string label, MouseEventHandler eventClicked, string tooltip = "", RectOffset padding = null, Color32? color = null)
        {
            var button = parent.AddUIComponent<UIButton>();
            button.anchor = UIAnchorStyle.Top | UIAnchorStyle.Left | UIAnchorStyle.Right;

            button = parent.AddUIComponent<UIButton>();
            //button.atlas = ResourceLoader.Atlas;
            //button.textScale = Constants.UITextScale;
            button.textPadding = padding;
            button.pivot = UIPivotPoint.TopRight;
            button.anchor = UIAnchorStyle.Right;
            button.zOrder = 0;
            button.normalBgSprite = "ButtonSmall";
            button.hoveredBgSprite = "ButtonSmallHovered";
            button.pressedBgSprite = "ButtonSmallPressed";
            button.focusedBgSprite = "ButtonSmall";
            button.text = label;
            button.tooltip = tooltip;
            button.eventClicked += eventClicked;
            button.autoSize = true;
            button.color = color;
            return button;
        }

    }
}
