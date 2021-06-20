﻿using ColossalFramework.UI;
using UnityEngine;
using CameraOperatorMod.GUI;

namespace CameraOperatorMod.Tool
{
    public static class ToolHelper
    {
        public static void LockedApply<T>(object lockObj, ref Config.Switchable<T> target, T value)
        {
            // don't change the switch...
            lock (lockObj) {
                target.Value = value;
            }
        }

        public static void LockedApply<T>(object lockObj, ref T target, T value)
        {
            //Log.Debug($"LockedApply: {value}");
            lock (lockObj) {
                target = value;
            }
        }

        public static SliderPane AddConfig<T>(UIPanel page, string label, string tooltip, SliderOption<T> opts, int? labelPadding = null, int? indentPadding = null, Color32? color = null, string bullet = null)
        {
            //var font = FontStore.Get(11);

            if (opts.onSwitched != null) { // has switch
                var cb = Helper.AddCheckBox(
                    ref page,
                    label: label,
                    tooltip: tooltip,
                    initialValue: opts.isEnabled,
                    (c, isEnabled) => {
                        opts.onSwitched.Invoke(c, isEnabled);
                    },
                    indentPadding: indentPadding
                );

                if (labelPadding.HasValue) {
                    cb.height += labelPadding.Value;
                } else {
                    cb.height += 1;
                }

            } else {
                Helper.AddLabel(ref page, label, tooltip, Helper.Padding(0, 0, 2, 0), color: color, bullet: bullet);
            }

            var pane = Helper.AddSliderPane<T>(ref page, opts);
            return pane;
        }
        public static UIButton AddButton<T>(ref UIPanel page, string label, MouseEventHandler eventClicked, string tooltip, int? labelPadding = null, int? indentPadding = null, Color32? color = null)
        {
            //var font = FontStore.Get(11);

            var pane = Helper.AddButton(ref page, label, eventClicked, tooltip, Helper.Padding(0, 0, 2, 0), color: color);
            return pane;
        }
    }
}
