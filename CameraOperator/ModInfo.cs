using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CameraOperatorMod
{
    public static class ModInfo
    {
        public const string
            Name = "Camera Operator Mod",
            Description = "Camera Operator Mod Description",
            COMIdentifier = "com.Tokachi269.CameraOperatorMod"
        ;

        public static System.Version Version
        {
            get => Assembly.GetExecutingAssembly().GetName().Version;
        }
        public static string VersionStr
        {
            get => Version.ToString();
        }
        public static FileVersionInfo VersionInfo
        {
            get => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        }
    }
}
