namespace CameraOperatorMod
{
    extern alias Cities;

    using System.Reflection;
    using ColossalFramework.UI;
    using global::CameraOperatorMod.GUI;
    using UnityEngine;

    internal class CameraManeger : MonoBehaviour
    {
        private void Start()
        {
            supportTool = base.gameObject.AddComponent<GUI.SupportTool>();
        }

        public static void ToggleUI()
        {
            if (ToolsModifierControl.GetCurrentTool<CameraTool>() != null)
            {
                DebugUtils.Log("Exiting Free Camera Mode");
                UIView.GetAView().FindUIComponent<UIButton>("Freecamera").SimulateClick();
                //GUI.ToolBase.mainWindow.isVisible = true;
            }
            else
            {
                //GUI.ToolBase.mainWindow.isVisible = !GUI.ToolBase.mainWindow.isVisible;
            }

        }

        public static CameraPath cameraPath;

        private SupportTool supportTool = null;

        public static Camera camera;

        public static CameraController cameraController;

        public static bool freeCamera = true;

        public static bool startSimulation = false;

        public static bool useFps = false;

        public static float fps = 15f;

        public static float originalFov = 45f;


        public static bool unlimitedCamera;


        //public static FieldInfo m_notificationAlpha;

        public static object EZC_config;

        public static FieldInfo EZC_fovSmoothing;

        public static bool EZC_originalFovSmoothing;
    }
}
