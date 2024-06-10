namespace MysteryFoxes.Systems.UI
{
    public interface IPanel
    {
        PanelType PanelType { get; }
        bool IsVisible { get; }

        internal void Close();

    }
}
