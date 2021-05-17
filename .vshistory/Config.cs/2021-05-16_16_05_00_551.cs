using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokachiCinematicCameraMod
{
    class Config
    {
        [Serializable]
        public class Switchable<T>
        {
            [NonSerialized]
            [XmlIgnore]
            public Type type = typeof(T);

            public bool Enabled { get; set; } = false;
            public T Value { get; set; }

            public delegate void SwitchHandler(ColossalFramework.UI.UIComponent c, bool isEnabled);
            public delegate void SlideHandler(ColossalFramework.UI.UIComponent c, float value);

            public SwitchHandler LockedSwitch(object lockTarget)
            {
                return (c, isEnabled) => {
                    lock (lockTarget)
                    {
                        Enabled = isEnabled;
                    }
                };
            }

            public SlideHandler LockedSlide(object lockTarget)
            {
                return (c, value) => {
                    lock (lockTarget)
                    {
                        Value = (T)Convert.ChangeType(value, type);
                    }
                };
            }

            public void AssignIfEnabled(ref T val)
            {
                if (Enabled)
                {
                    val = Value;
                }
            }

            public static implicit operator bool(Switchable<T> self)
            {
                return self.Enabled;
            }

            public static explicit operator T(Switchable<T> self)
            {
                return self.Value;
            }
        }
    }
}
