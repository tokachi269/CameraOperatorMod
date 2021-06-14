using ColossalFramework.UI;

namespace TokachiCinematicCameraMod.GUI
{
    public abstract class Editor<ItemsPanelType> : Editor
        where ItemsPanelType : AdvancedScrollablePanel
    {

    }
    public abstract class Editor : UIPanel
    {

        public abstract string Name { get; }
        public abstract string EmptyMessage { get; }

        public abstract bool AvailableItems { get; set; }
        public abstract bool AvailableContent { get; set; }

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