using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Production
{
    internal class ProductionObject : MonoBehaviour
    {
        Production production;

        [Inject]
        void Construct(Production production)
        {
            this.production = production;
        }
    }
}
