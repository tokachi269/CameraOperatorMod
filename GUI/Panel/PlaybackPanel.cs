using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class PlaybackPanel: UIPanel
    {
        int DefaultHeight = 120;
        public SliderProperty TimeLineSlider;

        private FieldProperty Fps;
        private UILabel Label;
        private ButtonPanel Button;

        public PlaybackPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            autoFitChildrenVertically = true;
            clipChildren = false;
            relativePosition = new Vector2(0, CameraOperator.DefaultRect.height - DefaultHeight);

            TimeLineSlider = AddUIComponent<SliderProperty>();
            TimeLineSlider.autoLayout = true;

            Button = AddUIComponent<ButtonPanel>();
            Button.autoLayout = true;

            Fps = AddUIComponent<FieldProperty>();
            Fps.autoLayout = true;
        }
    }
}