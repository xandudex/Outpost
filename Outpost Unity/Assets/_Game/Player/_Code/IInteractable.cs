namespace MysteryFoxes.Outpost.Player
{
    internal interface IInteractable { }
    internal interface IMountable : IInteractable
    {
        void Mount();
        void Unmount();
    }
}