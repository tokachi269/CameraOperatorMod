using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class PlaybackPanel: UIPanel
    {
        int DefaultHeight = 120;

        private FieldProperty field;
        private UISlider FOVSlider;
        private UITextField TextField;
        private UILabel label;

        public PlaybackPanel()
        {

            size = new Vector2(CameraOperator.DefaultRect.width, DefaultHeight);
            padding = Helper.Padding(4, 12, 4, 0);
            autoFitChildrenVertically = true;
            clipChildren = false;
            relativePosition = new Vector2(0, CameraOperator.DefaultRect.height - DefaultHeight);
        }
    }
}