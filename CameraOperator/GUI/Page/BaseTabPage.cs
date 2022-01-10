using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public abstract class BaseTabPage : UIComponent
    {
        public abstract CameraMode TabMode { get; }

        public abstract bool AvailableSetting { get; set; }
        public abstract bool AvailableContent { get; set; }
        public abstract bool AvailablePlay { get; set; }
        
        public override void Awake()
        {
            base.Awake();
        }

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

        public virtual void Render(RenderManager.CameraInfo cameraInfo) { }
        //public virtual bool OnShortcut(Event e) => false;
        public virtual bool OnEscape() => false;
    }

    public abstract class BaseTabPage<TCameraSettingPanelType, TListPanelType, TPlayPanelType> : BaseTabPage
        where TCameraSettingPanelType : CameraConfigPanel
        where TListPanelType : ScrollablePanel
        where TPlayPanelType : PlaybackPanel
    {
        protected bool NeedUpdate { get; set; }

        protected TCameraSettingPanelType CameraSettingPanel { get; set; }
        protected TListPanelType ListPanel { get; set; }
        protected TPlayPanelType PlayPanel { get; set; }

        public abstract void AddKnot();
        public abstract void Play();

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

            CameraSettingPanel = AddUIComponent<TCameraSettingPanelType>();
            CameraSettingPanel.backgroundSprite = "ScrollbarTrack";
            CameraSettingPanel.name = typeof(TCameraSettingPanelType).Name;
            CameraSettingPanel.clipChildren = false;


            ListPanel = AddUIComponent<TListPanelType>();
            ListPanel.backgroundSprite = "UnlockingItemBackground";
            ListPanel.name = typeof(TListPanelType).Name;
            ListPanel.clipChildren = false;

            PlayPanel = AddUIComponent<TPlayPanelType>();
            PlayPanel.backgroundSprite = "ScrollbarTrack";
            PlayPanel.relativePosition = new Vector2(0, CameraSettingPanel.height + ListPanel.height);
            PlayPanel.name = typeof(TPlayPanelType).Name;
            PlayPanel.clipChildren = false;

            SetPosition();
        }

        private void SetPosition()
        {
            ListPanel.relativePosition = new Vector2(0,CameraSettingPanel.height);
        }

    }
}