using UnityEngine;

namespace MysteryFoxes.Outpost.Player
{
    internal interface IInteractable { }
    internal interface IMountable : IInteractable
    {
        Transform SeatPoint { get; }
        Transform MountPoint { get; }
        void Mount();
        void Unmount();
    }
}