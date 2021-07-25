namespace CameraOperatorMod
{
    extern alias Cities;

    using System.Reflection;
    using ColossalFramework.UI;
    using global::CameraOperatorMod.GUI;
    using global::CameraOperatorMod.mode;
    using UnityEngine;

    public class CameraManeger : MonoBehaviour
    {
        public static CameraManeger Instance;

        internal void Initialize()
        {
            GUI.CameraOperator.CreatePanel();
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
