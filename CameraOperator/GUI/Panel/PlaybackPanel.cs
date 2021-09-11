using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class PlaybackPanel: UIPanel
    {
        int DefaultHeight = 120;
        public SliderPanel TimeLineSlider;

        private FieldProperty Fps;
        private UILabel Label;
        private ButtonPanel Button;

        public PlaybackPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            autoFitChildrenVertically = true;
            clipChildren = false;
            autoLayout = false;

            relativePosition = new Vector2(0, CameraOperator.DefaultRect.height - DefaultHeight);

            TimeLineSlider = AddUIComponent<SliderPanel>();
            // TimeLineSlider.Init(minValue: 0f, maxValue: 100, stepSize: 0.01f, defaultValue: 0f);

            Button = AddUIComponent<ButtonPanel>();

            Fps = AddUIComponent<FieldProperty>();

            autoLayoutDirection = LayoutDirection.Vertical;
            autoLayout = true;
        }
    }
}