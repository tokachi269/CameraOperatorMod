using CameraOperatorMod.GUI;
using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public class Rotate : BaseTabPage<CameraConfigPanel, AdvancedScrollablePanel, PlaybackPanel>
    {
        public override string Name => "Rotate";

        public static void Setup(ref UIPanel page)
        {

        }
    }
}
