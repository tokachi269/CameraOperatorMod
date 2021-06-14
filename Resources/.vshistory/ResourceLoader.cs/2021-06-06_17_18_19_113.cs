﻿using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraOperatorMod.Resources
{
    public class ResourceLoader
    {
        public static UITextureAtlas Atlas
        {
            get
            {
                if (atlas == null)
                {
                    atlas = GetAtlas();
                }
                return atlas;
            }
            set
            {
                atlas = value;
            }
        }
        public static UITextureAtlas GetAtlas()
        {
            //TODO true(UserMod.IsGame)
            return true ? UIView.GetAView().defaultAtlas : UIView.library?.Get<OptionsMainPanel>("OptionsPanel")?.GetComponent<UIPanel>()?.atlas;
        }

    }
}
