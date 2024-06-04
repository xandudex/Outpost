using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace MysteryFoxes.Outpost
{
    [HideMonoScript]
    internal class UniqueID : MonoBehaviour
    {
        [SerializeField, GUIColor("green"), ReadOnly]
        string id;

        public Guid Id => new(id);

        private void Reset()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
