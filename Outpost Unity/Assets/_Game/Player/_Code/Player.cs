using UnityEngine;
using VContainer;

namespace Game.Player
{
    internal class Player : MonoBehaviour
    {

        [Inject]
        void Construct(string str)
        {
            Debug.Log(str);
        }

    }
}