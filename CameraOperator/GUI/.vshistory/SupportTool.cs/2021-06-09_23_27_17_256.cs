using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class SupportTool : ToolBase
    {
        public override void Awake()
        {

        }

        public void Start()
        {
            Window.size = new Vector2(DefaultRect.width, DefaultRect.height);
            base.Start();

            //Title = Mod.ModInfo.ID;

            {
                var page = TabPage("Path");
                Path.Setup(ref page);
            }

            {
                var page = TabPage("Rotate");
                Rotate.Setup(ref page);
            }

            SelectTab(Config.SelectedTabIndex);
            // var page = TabPage("Path");
            // Window.AddUIComponent<UIPanel>();
            Window.Content.clipChildren = true;
            Window.clipChildren = false;
            Window.Show();
        }

        public static readonly Rect DefaultRect = new Rect(
            0f, 0f, 500f, 600f
        );
    }
}

