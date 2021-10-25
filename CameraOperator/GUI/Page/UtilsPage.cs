﻿using CameraOperator.Tool;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class UtilsPage : BaseTabPage
    {
        public override CameraMode TabName => CameraMode.Utils;

        public override bool AvailableSetting { get; set; }= false;
        public override bool AvailableContent { get; set; }= false;
        public override bool AvailablePlay { get; set; } = false;

        public void Awake()
        {
            base.Awake();

        }

        protected override void ActiveEditor()
        {
            throw new System.NotImplementedException();
        }
    }
}
