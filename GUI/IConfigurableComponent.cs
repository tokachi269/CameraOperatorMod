using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraOperatorMod.GUI
{
    interface IConfigurableComponent<ConfigT>
        where ConfigT : IConfig
    {
        ConfigT Config { get; set; }
    }
}
