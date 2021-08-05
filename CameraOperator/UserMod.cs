﻿using ICities;
using UnityEngine;

namespace CameraOperatorMod
{

    public class UserMod : LoadingExtensionBase, IUserMod
    {
        public string Name => "Camera Operator Mod";

        public string Description => "Camera Operator Mod Description";

        public void OnEnabled(){
            if (this.CameraManegerGameObject == null)
            {
                this.CameraManegerGameObject = new GameObject("CameraManeger");
                CameraManeger.Instance = CameraManegerGameObject.AddComponent<CameraManeger>();
                CameraManeger.Instance.Initialize();
            }
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (this.CameraManegerGameObject == null)
            {
                this.CameraManegerGameObject = new GameObject("CameraManeger");
                CameraManeger.Instance = CameraManegerGameObject.AddComponent<CameraManeger>();
                CameraManeger.Instance.Initialize();
            }

        }

        public override void OnLevelUnloading()
        {
            if (this.CameraManegerGameObject != null)
            {
                UnityEngine.Object.Destroy(this.CameraManegerGameObject);
                this.CameraManegerGameObject = null;
            }
        }

        public static void Remove()
        {
            if (CameraManeger.Instance is null)
            {
                //Destroy(CameraManeger.Instance);
                CameraManeger.Instance = null;
            }
        }
        public GameObject CameraManegerGameObject;
        public static readonly string SettingsFileName = "CameraOperatorMod";
    }

}