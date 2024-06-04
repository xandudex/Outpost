using MysteryFoxes.Outpost.Storages;
using System.Collections.Generic;

namespace MysteryFoxes.Outpost
{
    internal interface IConstructor : IZoneDetectable
    {
        IReadOnlyList<StorageModel> Storages { get; }
    }
}
