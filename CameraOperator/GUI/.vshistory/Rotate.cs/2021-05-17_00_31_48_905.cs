using CameraOperatorMod.GUI;
using ColossalFramework.UI;

namespace TokachiCinematicCameraMod.GUI
{
    class Rotate
    {

        public static void Setup(ref UIPanel page)
        {
            page.SetAutoLayout(LayoutDirection.Vertical, Helper.Padding(56, 2, 2, 2));
            page.autoFitChildrenVertically = true;
            page.backgroundSprite = "MenuPanelInfo";
            page.color = Helper.RGB(10, 10, 10);
            page.tooltip = "Rotate Base Panel";
        }
    }
}
