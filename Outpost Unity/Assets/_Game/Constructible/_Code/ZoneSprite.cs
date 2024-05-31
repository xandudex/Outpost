using Sirenix.OdinInspector;
using UnityEngine;

namespace MysteryFoxes.Outpost.Interactable
{
    [RequireComponent(typeof(Zone))]
    internal class ZoneSprite : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer spriteRenderer;

        [SerializeField, ReadOnly]
        Zone zone;

        private void Awake()
        {
            UpdateSize(zone.Size);
        }

        void UpdateSize(Vector3 size) => spriteRenderer.size = new(size.x, size.z);

#if UNITY_EDITOR
        private void Reset()
        {
            zone = GetComponent<Zone>();
            UnityEditor.EditorUtility.SetDirty(this);
        }

        void OnObjectValidate()
        {
            UpdateSize(zone.Size);
        }
#endif
    }
}
