using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public abstract class BaseTabPage : UIPanel
    {
        public abstract string Name { get; }

        public abstract bool AvailableSetting { get; set; }
        public abstract bool AvailableContent { get; set; }
        public abstract bool AvailablePlay { get; set; }

        public bool Active
        {
            get => enabled && isVisible;
            set
            {
                enabled = value;
                isVisible = value;

                if (value)
                    ActiveEditor();
            }
        }

        protected abstract void ActiveEditor();
        // public abstract void UpdateEditor();
        // public abstract void RefreshEditor();
        void awake()
        {

            isVisible = false;
            autoSize = false;
            size = parent.size;
            clipChildren = true;

        };
        public virtual void Render(RenderManager.CameraInfo cameraInfo) { }
        //public virtual bool OnShortcut(Event e) => false;
        public virtual bool OnEscape() => false;
    }

    public abstract class BaseTabPage<CameraSettingPanelType, ListPanelType, PlayPanelType> : BaseTabPage
        where CameraSettingPanelType : CameraConfigPanel
        where ListPanelType : AdvancedScrollablePanel
        where PlayPanelType : PlaybackPanel
    {
        protected bool NeedUpdate { get; set; }


        protected CameraSettingPanelType CameraSettingPanel { get; set; }
        protected ListPanelType ListPanel { get; set; }
        protected PlayPanelType PlayPanel { get; set; }

        public sealed override bool AvailableSetting
        {
            get => CameraSettingPanel.isEnabled;
            set => CameraSettingPanel.SetAvailable(value);
        }

        public sealed override bool AvailableContent
        {
            get => CameraSettingPanel.isEnabled;
            set => ListPanel.SetAvailable(value);
        }

        public sealed override bool AvailablePlay
        {
            get => CameraSettingPanel.isEnabled;
            set => PlayPanel.SetAvailable(value);
        }

        #region UPDATE ADD DELETE EDIT

        protected override void ActiveEditor()
        {
           // if (NeedUpdate)
           //     UpdateEditor();
           // else
           //     RefreshEditor();
        }

        #endregion
    }


}