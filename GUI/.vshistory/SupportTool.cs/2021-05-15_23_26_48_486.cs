using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class SupportTool : ToolBase
    {
        public override void Awake()
        {
            base.Awake();
            Tabs = new[] {
            new TabTemplate() {
                name = "Path" },
            new TabTemplate() {
                name = "Rotate" },
            new TabTemplate() {
                name = "Aerial" }
            };
        }

        public void Start()
        {
            base.Start();

            //Title = Mod.ModInfo.ID;
            // Window.height = 420;
            Window.size = new Vector2(DefaultRect.width, DefaultRect.height);

            SelectTab(Config.SelectedTabIndex);
            // var page = TabPage("Path");
            // Window.AddUIComponent<UIPanel>();
            Window.Content.clipChildren = true;
            Window.clipChildren = false;
            Window.Show();
        }

        public static readonly Rect DefaultRect = new Rect(
            0f, 0f, 500f, 700f
        );

    }
}
