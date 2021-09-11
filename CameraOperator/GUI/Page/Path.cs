using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public class Path :BaseTabPage<CameraConfigPanel, ScrollablePanel, PlaybackPanel>
    {
        public override string TabName => "Path";

        public PathController Tool => PathController.Instance;

        public void Awake()
        {
            base.Awake();
        }
    }
}
