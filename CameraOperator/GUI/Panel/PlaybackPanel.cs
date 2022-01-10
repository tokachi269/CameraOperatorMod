using System;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class PlaybackPanel: UIPanel
    {
        private int DefaultHeight = 95;
        public SliderPanel TimeLineSlider;

        public FieldProperty FPS;
        private UILabel Label;
        public ButtonPanel PlaybackButton;

        public PlaybackPanel()
        {
            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            clipChildren = false;

            relativePosition = new Vector2(0, CameraOperator.DefaultRect.height - DefaultHeight);

            TimeLineSlider = AddUIComponent<SliderPanel>();
            TimeLineSlider.name = nameof(TimeLineSlider);
            // TimeLineSlider.Init(minValue: 0f, maxValue: 100, stepSize: 0.01f, defaultValue: 0f);

            FPS = AddUIComponent<FieldProperty>();
            FPS.name = nameof(FPS);

            autoLayoutDirection = LayoutDirection.Vertical;
            autoLayout = true;
            autoLayout = false;

            PlaybackButton = AddUIComponent<ButtonPanel>();
            PlaybackButton.name = nameof(PlaybackButton);
            PlaybackButton.Init(55f, 55f, "▶", 3f);
            PlaybackButton.relativePosition = new Vector2(415f, 0f);

        }

        internal void SetAvailable(bool value)
        {
            throw new NotImplementedException();
        }
    }
}