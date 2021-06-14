using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public abstract class BaseTabPage<ItemsPanelType, ListPanelType, PlaybackPanelType> : BaseTabPage
        where ItemsPanelType : CameraConfigPanel
        where ListPanelType : AdvancedScrollablePanel
        where PlaybackPanelType : PlaybackPanel
    {
        protected ItemsPanelType CameraConfigPanel { get; set; }
        protected ListPanelType PlaybackPanel { get; set; }
        protected PlaybackPanelType playbackPanel { get; set; }

    }

    public abstract class BaseTabPage : UIPanel
    {
        public abstract string Name { get; }

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
        public abstract void UpdateEditor();
        public abstract void RefreshEditor();

        public virtual void Render(RenderManager.CameraInfo cameraInfo) { }
        //public virtual bool OnShortcut(Event e) => false;
        public virtual bool OnEscape() => false;
    }
}