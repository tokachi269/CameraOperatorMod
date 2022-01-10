﻿namespace CamOpr.GUI
{
    public class AboutPage : BaseTabPage
    {
        public override CameraMode TabMode => CameraMode.About;

        public override bool AvailableSetting { get; set; }= false;
        public override bool AvailableContent { get; set; }= false;
        public override bool AvailablePlay { get; set; } = false;

        public void Awake()
        {
            base.Awake();

        }

        protected override void ActiveEditor()
        {
            throw new System.NotImplementedException();
        }
    }
}
