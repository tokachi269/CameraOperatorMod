using CameraOperatorMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraOperatorMod
{
    public class PathController : BaseContoroller<Path>
    {
        public static PathController Instance;

        public override void AddItem(Path item)
        {
            if (!Items.ContainsKey(item.name))
            {
                Items.Add(item.name, item);
            }
        }

        public override void Play(string item)
        {
            if (!Items.ContainsKey(item))
            {
                Items[item].Play();
            }
        }
    }
}
