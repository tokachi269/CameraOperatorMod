using CameraOperatorMod.GUI;
using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public class Rotate : BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override string TabName => "Rotate";

        public void Awake()
        {
            base.Awake();
        }
    }
}
