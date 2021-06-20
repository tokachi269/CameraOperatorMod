namespace CameraOperatorMod
{
    extern alias Cities;

    using System.Reflection;
    using ColossalFramework.UI;
    using global::CameraOperatorMod.GUI;
    using global::CameraOperatorMod.mode;
    using UnityEngine;

    internal class CameraManeger : MonoBehaviour
    {
        void Awake()
        {
            GUI.CameraOperatorToolBase.CreatePanel();
        }

        public static void ToggleUI()
        {
            if (ToolsModifierControl.GetCurrentTool<CameraTool>() != null)
            {
                DebugUtils.Log("Exiting Free Camera Mode");
                UIView.GetAView().FindUIComponent<UIButton>("Freecamera").SimulateClick();
                //SupportTool.SetVisible(true);
            }
            else
            {
                //GUI.ToolBase.mainWindow.isVisible = !GUI.ToolBase.mainWindow.isVisible;
            }

        }

        public static CameraPath CameraPath;

        public static Camera Camera;

        public static CameraController CameraController;

        public static bool FreeCamera = true;

        public static bool StartSimulation = false;

        public static bool UseFps = false;

        public static float Fps = 15f;

        public static float OriginalFov = 45f;

        public static bool UnlimitedCamera;

        //public static FieldInfo m_notificationAlpha;

        public static object EZC_config;

        public static FieldInfo EZC_fovSmoothing;

        public static bool EZC_originalFovSmoothing;
    }
}
