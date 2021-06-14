using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public abstract class BaseTabPage<ItemsPanelType, ListPanelType, PlaybackPanelType> : BaseTabPage
        where ItemsPanelType : CameraConfigPanel
        where ListPanelType : AdvancedScrollablePanel
        where PlaybackPanelType : PlaybackPanel
    {
        protected bool NeedUpdate { get; set; }


        protected ItemsPanelType CameraConfigPanel { get; set; }
        protected ListPanelType PlaybackPanel { get; set; }
        protected PlaybackPanelType playbackPanel { get; set; }

        public sealed override bool AvailableItems
        {
            get => ItemsPanel.isEnabled;
            set => ItemsPanel.SetAvailable(value);
        }
        public sealed override bool AvailableContent
        {
            get => ItemsPanel.isEnabled;
            set => ContentPanel.SetAvailable(value);
        }


        #region UPDATE ADD DELETE EDIT

        protected override void ActiveEditor()
        {
            if (NeedUpdate)
                UpdateEditor();
            else
                RefreshEditor();
        }
        public sealed override void UpdateEditor()
        {
            if (Active)
            {
                AvailableItems = true;
                AvailableContent = true;

                var editObject = EditObject;
                ItemsPanel.SetObjects(GetObjects());
                ItemsPanel.SelectObject(editObject);

                SwitchEmptyMessage();

                NeedUpdate = false;
            }
            else
                NeedUpdate = true;
        }
        public sealed override void RefreshEditor()
        {
            if (EditObject is ObjectType editObject)
                OnObjectUpdate(editObject);
            else
                ItemsPanel.SelectObject(null);
        }

        public virtual void Add(ObjectType deleteObject)
        {
            ItemsPanel.AddObject(deleteObject);
            SwitchEmptyMessage();
        }
        public virtual void Delete(ObjectType deleteObject)
        {
            ItemsPanel.DeleteObject(deleteObject);
            SwitchEmptyMessage();
        }
        public virtual void Edit(ObjectType editObject = null)
        {
            ItemsPanel.EditObject(editObject);
            SwitchEmptyMessage();
        }

        protected abstract IEnumerable<ObjectType> GetObjects();

        #endregion
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