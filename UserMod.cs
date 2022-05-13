using ICities;
using UnityEngine;

namespace CamOpr
{

    public class UserMod : LoadingExtensionBase, IUserMod
    {
        public string Name => "Camera Operator Mod";

        public string Description => "Camera Operator Mod Description";

        public void OnEnabled() {
            if (this.CameraManegerGameObject == null)
            {
                if (GameObject.Find("CameraManeger") != null)
                {
                    Object.Destroy(GameObject.Find("CameraManeger"));
                }
                this.CameraManegerGameObject = new GameObject("CameraManeger");
                CameraOperator.Instance = CameraManegerGameObject.AddComponent<CameraOperator>();
                CameraOperator.Instance.Initialize();
                Debug.Log("OnEnabled");

            }
            else
            {

            }
        }
        public void OnDisabled()
        {
            if (this.CameraManegerGameObject == null)
            {
                if (this.CameraManegerGameObject != null)
                {
                    Object.Destroy(this.CameraManegerGameObject);
                    this.CameraManegerGameObject = null;
                }
                Debug.Log("OnDisabled");

            }
        }
        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group = helper.AddGroup("Stereoscopic View");

            group.AddButton("UI Initialize", () => CameraOperator.Instance.Initialize());
            group.AddSlider("Thickness of the display path", 1, 3, 0.1f, 0.1f, delegate(float p) { CameraOperator.PathThickness = p; });
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (this.CameraManegerGameObject == null)
            {
                if (GameObject.Find("CameraManeger") != null)
                {
                    Object.Destroy(GameObject.Find("CameraManeger"));
                }
                this.CameraManegerGameObject = new GameObject("CameraManeger");
                CameraOperator.Instance = CameraManegerGameObject.AddComponent<CameraOperator>();
                CameraOperator.Instance.Initialize();
                Debug.Log("OnEnabled");

            }
            else
            {

            }
        }

        public override void OnLevelUnloading()
        {
            if (this.CameraManegerGameObject != null)
            {
                Object.Destroy(this.CameraManegerGameObject);
                this.CameraManegerGameObject = null;
            }
        }

        public static void Remove()
        {
            if (CameraOperator.Instance is null)
            {
                //Destroy(CameraManeger.Instance);
                CameraOperator.Instance = null;
            }
        }

        public GameObject CameraManegerGameObject;
        public static readonly string SettingsFileName = "CameraOperatorMod";
    }
}