using UnityEngine;

namespace MysteryFoxes.Outpost.Items
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Outpost/Data/Item")]
    internal class ItemSO : ScriptableObject
    {
        [SerializeField]
        ItemObject prefab;

        [SerializeField]
        Sprite icon;

        public string Id => name;
        public ItemObject Prefab => prefab;
        public Sprite Icon => icon;
    }
}
