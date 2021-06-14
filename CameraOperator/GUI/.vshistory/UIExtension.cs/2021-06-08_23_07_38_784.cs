using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TokachiCinematicCameraMod.GUI
{
    public static class UIExtension
    {
        public static void SetAvailable(this UIComponent component, bool value)
        {
            component.isEnabled = value;
            component.opacity = value ? 1f : 0.15f;
        }
        public static bool IsHover(this UIComponent component, Vector3 mousePosition) => new Rect(component.absolutePosition, component.size).Contains(mousePosition);
    }
}
