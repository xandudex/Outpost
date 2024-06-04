using UnityEngine;

namespace MysteryFoxes.Outpost
{
    internal abstract class EntitySO : ScriptableObject, IEntityData
    {
        [SerializeField]
        GameObject prefab;

        public GameObject Prefab => prefab;
        public string Id => name;
    }
}
