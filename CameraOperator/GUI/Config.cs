using System;
using UnityEngine;

namespace CamOpr.GUI
{
    interface IConfig : ICloneable
    {

    }

    [Serializable]
    public class WindowConfig : IConfig
    {
        [SerializeField]
        public bool IsVisible = false;

        [SerializeField]
        public UIRect Rect;

        //[SerializeField]
        //[XmlArray]
        //IConfig[] Children;

        public object Clone() => MemberwiseClone();
    }

    [Serializable]
    public class TabbedWindowConfig : WindowConfig
    {
        public int SelectedTabIndex = 0;
    }
}
