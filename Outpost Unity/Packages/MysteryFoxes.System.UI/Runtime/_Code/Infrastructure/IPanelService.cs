namespace MysteryFoxes.Systems.UI
{

    public interface IPanelService
    {
        void Open(ICommonPanel panel, IPanel afterPanel = null);
        void Open<K>(IPayloadedPanel<K> panel, K payload, IPanel afterPanel = null);

        void Close(IPanel panel = null);
        void CloseAll();
    }
}
