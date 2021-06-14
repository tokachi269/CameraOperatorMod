using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public abstract class BaseTabPage : UIPanel
    {
        public abstract string Name { get; }


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

    public abstract class BaseTabPage<CameraConfigPanelType, ListPanelType, PlaybackPanelType> : BaseTabPage
        where CameraConfigPanelType : CameraConfigPanel
        where ListPanelType : AdvancedScrollablePanel
        where PlaybackPanelType : PlaybackPanel
    {
        protected bool NeedUpdate { get; set; }


        protected CameraConfigPanelType CameraConfigPanel { get; set; }
        protected ListPanelType ListPanel { get; set; }
        protected PlaybackPanelType PlaybackPanel { get; set; }

        public sealed override bool AvailableItems
        {
            get => CameraConfigPanel.isEnabled;
            set => CameraConfigPanel.SetAvailable(value);
        }
        public sealed override bool AvailableContent
        {
            get => CameraConfigPanel.isEnabled;
            set => ListPanel.SetAvailable(value);
        }


        #region UPDATE ADD DELETE EDIT

        protected override void ActiveEditor()
        {
            if (NeedUpdate)
                UpdateEditor();
            else
                RefreshEditor();
        }


        protected abstract IEnumerable<ObjectType> GetObjects();

        #endregion
    }


}