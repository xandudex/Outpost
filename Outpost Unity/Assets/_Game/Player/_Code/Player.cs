using MysteryFoxes.Outpost.Interactable;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    internal class Player : MonoBehaviour, IConstructor
    {

        [Inject]
        void Construct(string str)
        {
            Debug.Log(str);
        }

    }
}