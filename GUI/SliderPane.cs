using ColossalFramework.UI;
using System;

namespace CameraOperatorMod.GUI
{
    public class SliderOption<T>
    {
        public SliderOption(
            float minValue, float maxValue, float stepSize,
            float defaultValue,
            Config.Switchable<T>.SlideHandler onValueChanged
        ) {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.stepSize = stepSize;
            this.initialValue = defaultValue;
            this.onValueChanged = onValueChanged;
        }

        public bool hasField = true;
        public bool isEnabled;

        public float /* fixed type */ initialValue, minValue, maxValue, stepSize;
        public Config.Switchable<T>.SlideHandler onValueChanged;
        public Config.Switchable<T>.SwitchHandler onSwitched;
    }

    public class SliderPane
    {
        public UIPanel wrapper;
        public UISlider slider;
        public UITextField field;
    }
}
