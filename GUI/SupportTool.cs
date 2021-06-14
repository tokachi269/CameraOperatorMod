using UnityEngine;

namespace CameraOperatorMod.GUI
{
    class SupportTool : ToolBase
    {
        public void Start()
        {
            base.Start();
        }

        public static readonly Rect DefaultRect = new Rect(
            0f, 0f, 500f, 600f
        );
    }
}

