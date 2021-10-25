using ColossalFramework.UI;

namespace CameraOperatorMod.Resources
{
    public class ResourceLoader
    {
        private static UITextureAtlas atlas;
        public static UITextureAtlas Atlas
        {
            get
            {
                if (atlas == null)
                {
                    atlas = GetAtlas();
                }
                return atlas;
            }
            set
            {
                atlas = value;
            }
        }

        public static UITextureAtlas GetAtlas()
        {
            //TODO true(UserMod.IsGame)
            return true ? UIView.GetAView().defaultAtlas : UIView.library?.Get<OptionsMainPanel>("OptionsPanel")?.GetComponent<UIPanel>()?.atlas;
        }
    }
}
