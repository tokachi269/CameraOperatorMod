namespace TokachiCinematicCameraMod.GUI
{
    public abstract class Editor<ItemsPanelType> : Editor, IEditor<ObjectType>
        where ItemsPanelType : AdvancedScrollablePanel
}