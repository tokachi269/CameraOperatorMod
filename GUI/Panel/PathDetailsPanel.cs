using System;
using System.Collections.Generic;
using CamOpr.Tool;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class PathDetailsPanel : EditorPropertyItem
    {
        public Dictionary<EPropaties, EditorPropertyItem> Properties = new Dictionary<EPropaties, EditorPropertyItem>();
        public ButtonProperty ButtonPanel;

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
            Content.autoLayout = true;
            Content.autoLayoutDirection = LayoutDirection.Vertical;
            Content.height = 200f; 
            AddProperty(EPropaties.Position, Content.AddUIComponent<Vector3Property>());
            AddProperty(EPropaties.Rotation, Content.AddUIComponent<Vector3Property>());
            AddProperty(EPropaties.FOV, Content.AddUIComponent<FieldProperty>());
            AddProperty(EPropaties.Duration, Content.AddUIComponent<FieldProperty>());
            // AddProperty(EPropaties.Button, Content.AddUIComponent<ButtonProperty>());
            SetRowHeights();
            Content.autoLayout = true;

            ButtonPanel = AddUIComponent<ButtonProperty>();

            InitPanel();
            Content.autoLayout = true;

        }

        internal void Refresh(CameraConfig cp)
        {
            Properties[EPropaties.Position].UpdateValues(cp.Position);
            Properties[EPropaties.Rotation].UpdateValues(cp.Rotation);
            Properties[EPropaties.FOV].UpdateValues(cp.Fov);
            Properties[EPropaties.Duration].UpdateValues(cp.Duration);
        }

        protected override void InitPanel()
        {
            Debug.Log("☆☆☆PathDetailsPanel InitPanel()");
            ButtonPanel.Button.text = "Delete";
            ButtonPanel.autoLayout = false;
            ButtonPanel.relativePosition = new Vector2(height - ButtonPanel.height, 0);
        }

        private void AddProperty(EPropaties key, EditorPropertyItem property)
        {
            Properties.Add(key, property);
            property.name = key.ToString();
            if (property.HasLabel)
            {
                property.Label.text = key.ToString();
            }
        }

        protected override void OnSizeChanged()
        {
            foreach (var p in Properties)
            {
                p.Value.Refresh(false);
            }
        }

        private void SetRowHeights()
        {
            foreach (var p in Properties)
            {
                p.Value.size = new Vector2((CameraOperator.DefaultRect.width / 1.5f) - padding.horizontal, DefaultHeight);
                p.Value.color = Helper.GrayScale(30);
                p.Value.autoLayoutStart = LayoutStart.BottomLeft;
            }
        }

        public override void UpdateValues<T>(T value)
        {
            throw new NotImplementedException();
        }
    }
}