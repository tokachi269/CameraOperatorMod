namespace CameraOperatorMod
{
    extern alias Cities;

    using ColossalFramework.UI;
    using global::CameraOperator.Tool;
    using System.Collections.Generic;
    using UnityEngine;

    public enum CameraMode
    {
        Path,
        Rotate,
        Utils,
        About
    }

    public struct Tuple
    {
        public CameraMode Mode { get; private set; }
        public string Name { get; private set; }

        internal Tuple(CameraMode first, string second)
        {
            Mode = first;
            Name = second;
        }
    }
    public class CameraOperator : MonoBehaviour
    {
        public static CameraOperator Instance;

        public static Camera mainCamera;
        public static CameraController cameraController;

        public static Dictionary<Tuple, Object> Modes = new Dictionary<Tuple, Object>();

        internal void Initialize()
        {

            Modes.Add(new Tuple(CameraMode.Path, "default"), new PathTool());
            Modes.Add(new Tuple(CameraMode.Rotate, "default"), new RotateTool());

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
