namespace MysteryFoxes.Systems.UI
{
    public interface IPayloadedPanel<T> : IPanel
    {
        internal void Show(T payload);
    }
}
