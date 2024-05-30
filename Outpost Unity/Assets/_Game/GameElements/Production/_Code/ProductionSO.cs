using UnityEngine;

namespace MysteryFoxes.Outpost.Production
{
    [CreateAssetMenu(fileName = "Production Data", menuName = "Outpost/Data/Production")]
    internal class ProductionSO : ScriptableObject
    {
        [SerializeField]
        ProductionObject prefab;

        public ProductionObject Prefab => prefab;
    }
}
