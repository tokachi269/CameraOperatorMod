using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod.Resources
{
    public class ResourceLoader
    {
        public static UITextureAtlas GetAtlas()
        {
            return true ? UIView.GetAView().defaultAtlas : UIView.library?.Get<OptionsMainPanel>("OptionsPanel")?.GetComponent<UIPanel>()?.atlas;
        }

    }
}
