using MysteryFoxes.Outpost.Constructions;
using System.Collections.Generic;

namespace MysteryFoxes.Outpost.Services
{
    internal interface IConstructionService
    {
        IReadOnlyList<Construction> Constructions { get; }
    }
}
