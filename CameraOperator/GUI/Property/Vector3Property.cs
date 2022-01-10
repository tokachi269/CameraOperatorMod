using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
{
    public class Vector3Property : EditorPropertyItem
    {
        protected FieldType FieldX { get; set; }
        protected FieldType FieldY { get; set; }
        protected FieldType FieldZ { get; set; }

        public override int ItemsPadding => 4;
        public override float DefaultHeight => 28;
        public override bool HasLabel => true;

        public Vector3Property()
        {
            FieldX = Content.AddUIComponent<FieldType>();
            FieldY = Content.AddUIComponent<FieldType>();
            FieldZ = Content.AddUIComponent<FieldType>();
            InitPanel();
        }

        protected override void InitPanel()
        {
            autoLayoutDirection = LayoutDirection.Horizontal;
            clipChildren = false;
            autoLayoutPadding = Helper.Padding(0, ItemsPadding, 0, ItemsPadding);

            autoLayout = true;

            Label.width = base.width - Content.width;
        }

        public override void UpdateValues<T>(T value)
        {
            Vector3 vector3;

            if (value is Vector3)
            {
                vector3 = (Vector3)(object)value;
            }
            else if (value is Quaternion)
            {
                vector3 = ((Quaternion)(object)value).eulerAngles;
            }
            else
            {
                Debug.Log("Must be a Vector3 type");
                return;
            }

            FieldX.text = vector3.x.ToString();
            FieldY.text = vector3.y.ToString();
            FieldZ.text = vector3.z.ToString();
        }
    }
}
