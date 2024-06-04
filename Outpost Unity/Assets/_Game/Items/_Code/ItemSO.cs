using UnityEngine;

namespace MysteryFoxes.Outpost.Items
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Outpost/Data/Item")]
    internal class ItemSO : EntityConfig
    {
        [SerializeField]
        Sprite icon;

        public Sprite Icon => icon;
    }
}
