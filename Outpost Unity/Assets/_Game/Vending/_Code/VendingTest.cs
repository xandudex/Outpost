using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Vending
{
    internal class VendingTest : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        int count;

        IReadOnlyList<VendingMachine> list;

        [Inject]
        void Construct(IReadOnlyList<VendingMachine> list)
        {
            this.list = list ?? new List<VendingMachine>();

        }

        private void Update()
        {
            count = list.Count;
        }
    }
}
