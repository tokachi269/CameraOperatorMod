using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public abstract class BaseTabPage : UIComponent
    {
        public abstract string TabName { get; }

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

        public abstract void AddKnot();


        public virtual void Render(RenderManager.CameraInfo cameraInfo) { }
        //public virtual bool OnShortcut(Event e) => false;
        public virtual bool OnEscape() => false;
    }

    public abstract class BaseTabPage<CameraSettingPanelType, ListPanelType, PlayPanelType> : BaseTabPage
        where CameraSettingPanelType : CameraConfigPanel
        where ListPanelType : ScrollablePanel
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

        public override void Awake()
        {
            base.Awake();

            isVisible = false;
            autoSize = false;
            clipChildren = true;
            relativePosition = Vector2.zero;
            // backgroundSprite = "UnlockingItemBackground";

            CameraSettingPanel = AddUIComponent<CameraSettingPanelType>();
            CameraSettingPanel.backgroundSprite = "ScrollbarTrack";
            CameraSettingPanel.name = typeof(CameraSettingPanelType).Name;
            CameraSettingPanel.clipChildren = false;


            ListPanel = AddUIComponent<ListPanelType>();
            ListPanel.backgroundSprite = "UnlockingItemBackground";
            ListPanel.name = typeof(ListPanelType).Name;
            ListPanel.clipChildren = false;

            PlayPanel = AddUIComponent<PlayPanelType>();
            PlayPanel.backgroundSprite = "ScrollbarTrack";
            PlayPanel.relativePosition = new Vector2(0, CameraSettingPanel.height + ListPanel.height);
            PlayPanel.name = typeof(PlayPanelType).Name;
            PlayPanel.clipChildren = false;

            setPosition();
        }

        private void setPosition()
        {
            ListPanel.relativePosition = new Vector2(0,CameraSettingPanel.height);
        }

    }
}