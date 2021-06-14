﻿using ColossalFramework.UI;

namespace CameraOperatorMod.GUI
{
    public abstract class BaseTabPagePanel<ItemsPanelType, ItemsPanelType2, ItemsPanelType3> : BaseTabPage
        where ItemsPanelType : CameraConfigPanel
        where ItemsPanelType2 : AdvancedScrollablePanel
        where ItemsPanelType3 : PlaybackPanel
    {
        private CameraConfigPanel CameraConfigPanel;
        private PlaybackPanel PlaybackPanel;

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