namespace MysteryFoxes.Systems.UI
{
    public abstract class PayloadedPanel<T> : PanelBase, IPayloadedPanel<T>
    {
        T payload;
        void IPayloadedPanel<T>.Open(T payload)
        {
            this.payload = payload;
            gameObject.SetActive(true);
        }
    }
}
