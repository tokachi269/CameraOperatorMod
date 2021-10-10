namespace CameraOperatorMod
{
    extern alias Cities;
    using ColossalFramework.UI;

    using UnityEngine;

    public class CameraManeger : MonoBehaviour
    {
        public static CameraManeger Instance;

        public static Camera mainCamera;
        public static CameraController cameraController;
        internal void Initialize()
        {
            GUI.CameraOperator.CreatePanel();
            mainCamera = Camera.main;
            cameraController = mainCamera.GetComponent<CameraController>();
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

    }
}
