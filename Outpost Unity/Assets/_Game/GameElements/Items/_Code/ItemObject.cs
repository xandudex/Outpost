using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Items
{
    internal class ItemObject : MonoBehaviour
    {
        Item item;

        [Inject]
        void Construct(Item item)
        {
            this.item = item;
        }

        public Item Item => item;
    }
}
