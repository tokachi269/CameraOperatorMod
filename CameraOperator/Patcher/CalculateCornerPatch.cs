namespace CameraOperatorMod.Patcher {
    using HarmonyLib;
    using JetBrains.Annotations;
    using System.Reflection;
    using UnityEngine;

    [UsedImplicitly]
    [HarmonyPatch]
    static class CalculateCornerPatch {
        [HarmonyPatch(typeof(Camera), "set_fieldOfView")]
        static void Prefix()
        {
            Debug.Log("Patched");
        }
    }
}
