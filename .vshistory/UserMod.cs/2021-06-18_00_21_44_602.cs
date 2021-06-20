using ICities;
using UnityEngine;

namespace CameraOperatorMod
{
    public class CameraOperatorMod :  LoadingExtensionBase, IUserMod
    {
        public string Name => "Camera Operator Mod";

        public string Description => "Camera Operator Mod Description";

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (this.CameraManegerGameObject == null)
            {
                this.CameraManegerGameObject = new GameObject("CameraManeger");
                this.CameraManegerGameObject.AddComponent<CameraManeger>();
                CameraManegerGameObject.Init();
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

        public GameObject CameraManegerGameObject;
        public static readonly string SettingsFileName = "CameraOperatorMod";
    }

}