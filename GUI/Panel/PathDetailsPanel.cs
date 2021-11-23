using ColossalFramework.UI;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CamOpr.GUI
{
    public class PathDetailsPanel : UIPanel
    {

        Dictionary<EPropaties, EditorPropertyItem> Propertys = new Dictionary<EPropaties, EditorPropertyItem>();

        private enum EPropaties
        {
            PositionProperty,
            RotationProperty,
            FovProperty,
            FpsProperty,
            DurationProperty,
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

            Propertys.Add(EPropaties.PositionProperty, AddUIComponent<Vector3Property>());

            Propertys.Add(EPropaties.RotationProperty, AddUIComponent<Vector3Property>());

            Propertys.Add(EPropaties.FovProperty, AddUIComponent<FieldProperty>());

            Propertys.Add(EPropaties.FpsProperty, AddUIComponent<FieldProperty>());

            Propertys.Add(EPropaties.DurationProperty, AddUIComponent<FieldProperty>());
            
            InitPanel();
        }

        protected void InitPanel()
        {
            Propertys[EPropaties.PositionProperty].name = EPropaties.PositionProperty.ToString();
            Propertys[EPropaties.PositionProperty].Label.text = "Position";

            Propertys[EPropaties.RotationProperty].name = EPropaties.RotationProperty.ToString();
            Propertys[EPropaties.RotationProperty].Label.text = "Rotation";

            Propertys[EPropaties.FovProperty].name = EPropaties.FovProperty.ToString();
            //Propertys[EPropaties.FovProperty].Label.text = "FOV";

            Propertys[EPropaties.FpsProperty].name = EPropaties.FpsProperty.ToString();
            //Propertys[EPropaties.FpsProperty].Label.text = "Fps";

            Propertys[EPropaties.DurationProperty].name = EPropaties.DurationProperty.ToString();
            //Propertys[EPropaties.DurationProperty].Label.text = "Duration";

            SetRowHeights();
        }

        private void SetRowHeights()
        {
            foreach (var p in Propertys)
            {
                p.Value.size = new Vector2((CameraOperator.DefaultRect.width / 1.5f) - padding.horizontal, DefaultHeight);
                p.Value.color = Helper.GrayScale(30);
                p.Value.autoLayoutStart = LayoutStart.TopRight;

            }

            /*
                        FieldInfo[] fields = GetType().GetFields();

                        foreach (FieldInfo field in fields)
                        {
                            Debug.Log(field);

                            var f = typeof(UIPanel).GetProperty("size",
                                BindingFlags.Public | BindingFlags.NonPublic |
                                BindingFlags.Instance | BindingFlags.Static |
                                BindingFlags.DeclaredOnly);

                            Debug.Log(f);
                           // foreach(var x in f)
                            {
                                var a = f.GetValue(field, null);

                                Debug.Log(a);

                                if (!(f is null))
                                {
                                    ((PropertyInfo)f).SetValue(a, new Vector2(CameraOperator.DefaultRect.width / 1.5f, DefaultHeight), null);
                                }
                            }
                            //f.SetValue(type, new Vector2(CameraOperator.DefaultRect.width / 1.5f, DefaultHeight)) ;

                        }
            */
        }
    }
}