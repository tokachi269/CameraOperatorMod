
using ICities;
using ColossalFramework;
using ColossalFramework.UI;
using CitiesHarmony.API;
using UnityEngine;

namespace CameraOperatorMod
{
    public class CameraOperatorMod :  LoadingExtensionBase, IUserMod
    {
        public string Name => "Camera Operator Mod";
        public string Description => "Camera Operator Mod Description";

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (this.cameraManeger == null)
            {
                this.cameraManeger = new GameObject("{gameObject.name}.CameraOperatorMod");
                this.cameraManeger.AddComponent<CameraManeger>();
            }

        }
        public override void OnLevelUnloading()
        {
            if (this.cameraManeger != null)
            {
                UnityEngine.Object.Destroy(this.cameraManeger);
                this.cameraManeger = null;
            }
        }

        public GameObject cameraManeger;
        // Token: 0x04000024 RID: 36
        public static readonly string settingsFileName = "CameraOperatorMod";
    }

}