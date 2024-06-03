using UnityEngine;

namespace MysteryFoxes.Outpost.Production
{
    internal class ProductionMarker : MonoBehaviour
    {
        [SerializeField]
        ProductionSO production;

        public ProductionSO Production => production;
    }
}
