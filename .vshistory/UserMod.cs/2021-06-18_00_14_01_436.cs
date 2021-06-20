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
            if (this.CameraManeger == null)
            {
                this.CameraManeger = new GameObject("CameraManeger");
                this.CameraManeger.AddComponent<CameraManeger>();
            }
        }

        public override void OnLevelUnloading()
        {
            if (this.CameraManeger != null)
            {
                UnityEngine.Object.Destroy(this.CameraManeger);
                this.CameraManeger = null;
            }
        }

        public GameObject CameraManeger;
        public static readonly string SettingsFileName = "CameraOperatorMod";
    }

}