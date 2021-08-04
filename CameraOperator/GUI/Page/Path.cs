using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public class Path :BaseTabPage<CameraConfigPanel, AdvancedScrollablePanel, PlaybackPanel>
    {
        public override string TabName => "Path";

       public void Awake()
        {
            base.Awake();

        }
    }
}
