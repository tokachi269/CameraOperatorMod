using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public class CameraConfigPanel :UIPanel
    {
                    {
                var pane = page.AddUIComponent<UIPanel>();
        pane.width = pane.parent.width - page.padding.horizontal;
                pane.padding = Helper.Padding(4, 12, 4, 0);
                pane.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(0, 0, 2, 0));
                pane.autoFitChildrenVertically = true;
            
                ToolHelper.AddConfig(
                     ref pane,
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