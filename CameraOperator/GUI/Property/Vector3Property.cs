using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class Vector3Property : EditorPropertyItem
    {
        protected FieldProperty FieldX { get; set; }
        protected FieldProperty FieldY { get; set; }
        protected FieldProperty FieldZ { get; set; }

        public override int ItemsPadding => 4;
        public override float DefaultHeight => 28;
        public override bool hasLabel => true;
        public Vector3Property()
        {
            FieldX = Content.AddUIComponent<FieldProperty>();
            FieldY = Content.AddUIComponent<FieldProperty>();
            FieldZ = Content.AddUIComponent<FieldProperty>();
            InitPanel();
        }

        protected override void InitPanel()
        {

            autoLayoutDirection = LayoutDirection.Horizontal;
            clipChildren = false;
            autoLayoutPadding = Helper.Padding(ItemsPadding, ItemsPadding, 0, 0);

            FieldX.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);
            FieldX.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);

            FieldY.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);
            FieldY.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);

            FieldZ.size = new Vector2(width - ItemsPadding * 2, DefaultHeight);
            FieldZ.relativePosition = new Vector3(ItemsPadding, (height - DefaultHeight) / 2);

            autoLayout = true;
            autoLayout = false;
            autoLayout = true;

            Content.autoLayout = true;
        }
    }
}
