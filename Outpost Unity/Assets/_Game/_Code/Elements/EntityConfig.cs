using UnityEngine;

namespace MysteryFoxes.Outpost
{
    internal abstract class EntityConfig : ScriptableObject, IEntityData
    {
        [SerializeField]
        GameObject prefab;

        public GameObject Prefab => prefab;
        public string Id => name;
    }
}
