using System;
using UnityEngine;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace CameraOperator.Tool
{
    public class ToolController : MonoBehaviour
    {
        [SerializeField]
        public PathTool PathTool;

        [SerializeField]
        public RotateTool RotateTool;
        public static string RecoveryDirectory => System.IO.Path.Combine(Directory.GetCurrentDirectory(), "CameraOperator");
        
        public Dictionary<string, BaseCameraMode> saves;
        void Start()
        {
            PathTool = gameObject.AddComponent<PathTool>();
            RotateTool = gameObject.AddComponent<RotateTool>();

            PathTool.AddKnot(new Vector3(0, 0, 1), new Quaternion(0, 0, 0, 1), 60);
            PathTool.AddKnot(new Vector3(1, 1, 1), new Quaternion(0, 0, 0, 1), 60);
            PathTool.AddKnot(new Vector3(0, 2, 5), new Quaternion(0, 0, 0, 1), 60);
            PathTool.AddKnot(new Vector3(0, -2, 1), new Quaternion(0, 0, 0, 1), 60);
            PathTool.AddKnot(new Vector3(5, 1, 1), new Quaternion(0, 0, 0, 1), 60);

            //PathTool.AddKnot(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1), 60);
            //PathTool.AddKnot(new Vector3(0, 1, 1), new Quaternion(0, 0, 0, 1), 60);
            //PathTool.AddKnot(new Vector3(0, 2, 0), new Quaternion(0, 0, 0, 1), 60);
            //PathTool.AddKnot(new Vector3(0, 3, 3), new Quaternion(0, 0, 0, 1), 60);
            //PathTool.AddKnot(new Vector3(0, 4, 0), new Quaternion(0, 0, 0, 1), 60);
            PathTool.AddLookAt(new Vector3(0, 4, 0), new Quaternion(0, 0, 0, 1), 60);

            RotateTool.AddKnot(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1), 60);

            saves = new Dictionary<string, BaseCameraMode>();
        }


        void Update()
        {
            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Input.GetKey("h"))
            {
                PathTool.GetCursorPositionPath();

                if (Input.GetMouseButtonDown(0))
                {
                    PathTool.AddKnotMiddle();
                }
            }
            if (Input.GetKey("f"))
            {
                PathTool.MoveKnot();

                if (Input.GetMouseButtonDown(0))
                {
                    PathTool.AddKnotMiddle();
                }
            }

            if (Input.GetKeyDown("k"))
            {
                PathTool.AddKnot(CameraUtils.CameraPosition());
                Debug.Log("Add Knot Succeed");
                PathTool.render.Display();
            }
            if (Input.GetKeyDown("j"))
            {
                PathTool.RemoveKnot();
                Debug.Log("Remove Knot Succeed");
                PathTool.render.Display();
            }
            if (Input.GetKeyDown("t"))
            {
                if (PathTool != null)
                {
                    StartCoroutine(PathTool.Play());
                }
                Debug.Log("PathTool Start!!");
            }

            if (Input.GetKeyDown("y"))
            {
                if (RotateTool!= null)
                {
                    StartCoroutine(RotateTool.Play());
                }
                Debug.Log("Rotate Start!!");
            }
            if (Input.GetKeyDown("u"))
            {
                if (PathTool != null)
                {
                    PathTool.serializer.Serialize("xx");
                }
                Debug.Log("PathTool Serialized");
            }
        }

    }
}
