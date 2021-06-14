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
                name = "Aerial" },
            new TabTemplate() {
                name = "Fixed" }
            };
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

            //SelectTab(Config.SelectedTabIndex);
            // var page = TabPage("Path");
            // Window.AddUIComponent<UIPanel>();
            Window.Content.clipChildren = true;
            Window.clipChildren = false;
            Window.Show();
        }
        private void CreateEditor<TabPage>() where TabPage : BaseTabPage
        {
            var editor = AddUIComponent<TabPage>();
            editor.Active = false;
            editor.Init(this);
            TabStrip.AddTab(editor);

            Editors.Add(editor);
        }
        public static readonly Rect DefaultRect = new Rect(
            0f, 0f, 500f, 600f
        );
    }
}
