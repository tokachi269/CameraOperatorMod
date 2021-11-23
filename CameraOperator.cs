extern alias Cities;

using System.Collections.Generic;
using System.Reflection;
using CamOpr.Tool;
using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr
{
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

        public static Camera MainCamera;
        public static CameraController CameraController;
        public static FieldInfo M_notificationAlpha;

        public static Dictionary<Tuple, Object> Modes = new Dictionary<Tuple, Object>();

        public static Coroutine crt;

        internal void Initialize()
        {

            Modes.Add(new Tuple(CameraMode.Path, "default"), this.gameObject.AddComponent<PathTool>());
            Modes.Add(new Tuple(CameraMode.Rotate, "default"), this.gameObject.AddComponent<RotateTool>());

            GUI.CameraOperator.CreatePanel();
            MainCamera = Camera.main;
            CameraController = MainCamera.GetComponent<CameraController>();
            M_notificationAlpha = typeof(NotificationManager).GetField("m_notificationAlpha", BindingFlags.Instance | BindingFlags.NonPublic);

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

        public static void EnsureUIComponentsLayout()
        {
            UIComponent[] componentsInChildren = UIView.GetAView().GetComponentsInChildren<UIComponent>();
            for (int i = 0; i < componentsInChildren.Length; i++)
            {
                if (componentsInChildren[i] != null)
                {
                    UIAnchorStyle anchor = componentsInChildren[i].anchor;
                }
            }
        }

    }
}
