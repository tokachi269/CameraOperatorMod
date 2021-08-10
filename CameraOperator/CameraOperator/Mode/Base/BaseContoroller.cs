using System.Collections.Generic;

namespace CameraOperatorMod
{
    public abstract class BaseContoroller<TItem>
        where TItem : BaseCameraMode
    {
        public Dictionary<string, TItem> Items = new Dictionary<string, TItem>();

        public abstract void AddItem(TItem item);

        public abstract void Play(string item);
    }
}
