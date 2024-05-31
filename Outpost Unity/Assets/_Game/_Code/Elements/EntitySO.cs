using UnityEngine;

namespace MysteryFoxes.Outpost
{
    internal abstract class EntitySO : ScriptableObject
    {
        [SerializeField]
        GameObject prefab;

        public GameObject Prefab => prefab;
        public string Id => name;
    }
}
