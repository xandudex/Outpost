using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace MysteryFoxes.Outpost
{
    [HideMonoScript]
    internal class UniqueID : MonoBehaviour
    {
        [SerializeField, ReadOnly, HorizontalGroup, GUIColor("green")]
        string id;

        public Guid Id => new(id);

        [Button("Generate"), HorizontalGroup(60)]
        private void Reset()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
