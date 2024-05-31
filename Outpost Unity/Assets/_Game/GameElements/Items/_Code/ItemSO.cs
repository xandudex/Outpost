using MysteryFoxes.Outpost.Interactable;
using UnityEngine;

namespace MysteryFoxes.Outpost.Items
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Outpost/Data/Item")]
    internal class ItemSO : EntitySO
    {
        [SerializeField]
        Sprite icon;

        public Sprite Icon => icon;
    }
}
