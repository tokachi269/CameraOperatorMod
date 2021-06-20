using CameraOperatorMod.Tool;
using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
        public void Awake()
        {
            base.Awake();
            {
                var panel = parent.AddUIComponent<UIPanel>();
                panel.width = parent.width;
                panel.padding = Helper.Padding(4, 12, 4, 0);
                panel.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
                panel.autoFitChildrenVertically = true;

                ToolHelper.AddConfig(
                     ref panel,
                     "FOV",
                     "default: 60",
                     opts: new SliderOption<float>(
                         minValue: 1.0f,
                         maxValue: 150.0f,
                         stepSize: 0.1f,
                         defaultValue: 60f,
                         (c, value) => {
                             Debug.Log("Slider Cahanged");
                         })
                     {
                     },
                     labelPadding: 4,
                     indentPadding: 12
                );
            }
        }
    }
}