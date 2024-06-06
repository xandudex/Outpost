using R3;
using UnityEngine;

namespace MysteryFoxes.Global.Services
{
    internal interface ISceneLoader
    {
        ReadOnlyReactiveProperty<float> Progress { get; }
        Awaitable LoadScene(int id);
    }
}