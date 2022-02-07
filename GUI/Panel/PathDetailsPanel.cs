using System;
using System.Collections.Generic;
using CamOpr.Tool;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class PathDetailsPanel : UIPanel
    {
        public Dictionary<EPropaties, EditorPropertyItem> Propertys = new Dictionary<EPropaties, EditorPropertyItem>();

        public enum EPropaties
        {
            Index,
            Position,
            Rotation,
            FOV,
            Duration,
            Button
        }

        private int defaultHeight = 26;

        public int DefaultHeight
        {
            get => defaultHeight;
            set {
                SetRowHeights();
                defaultHeight = value;
            }
        }

        public PathDetailsPanel()
        {
            autoLayout = true;
            autoLayoutDirection = LayoutDirection.Vertical;
            padding = Helper.Padding(2, 4, 4);
            color = Helper.RGBA(149, 157, 163, 215);
            backgroundSprite = "WhiteRect";

            AddProperty(EPropaties.Position, AddUIComponent<Vector3Property>());
            AddProperty(EPropaties.Rotation, AddUIComponent<Vector3Property>());
            AddProperty(EPropaties.FOV, AddUIComponent<FieldProperty>());
            AddProperty(EPropaties.Duration, AddUIComponent<FieldProperty>());
            AddProperty(EPropaties.Button, AddUIComponent<ButtonProperty>());

            SetRowHeights();
        }

        internal void Refresh(CameraConfig cp)
        {
            Propertys[EPropaties.Position].UpdateValues(cp.Position);
            Propertys[EPropaties.Rotation].UpdateValues(cp.Rotation);
            Propertys[EPropaties.FOV].UpdateValues(cp.Fov);
            Propertys[EPropaties.Duration].UpdateValues(cp.Duration);
        }

        protected void InitPanel()
        {
            SetRowHeights();
        }

        private void AddProperty(EPropaties key, EditorPropertyItem property)
        {
            Propertys.Add(key, property);
            property.name = key.ToString();
            if (property.HasLabel)
            {
                property.Label.text = key.ToString();
            }
        }

        protected override void OnSizeChanged()
        {
            foreach (var p in Propertys)
            {
                p.Value.Refresh(false);
            }
        }

        private void SetRowHeights()
        {
            foreach (var p in Propertys)
            {
                p.Value.size = new Vector2((CameraOperator.DefaultRect.width / 1.5f) - padding.horizontal, DefaultHeight);
                p.Value.color = Helper.GrayScale(30);
                p.Value.autoLayoutStart = LayoutStart.BottomLeft;
            }
        }
    }
}