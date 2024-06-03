using ObservableCollections;
using R3;
using UnityEngine;

namespace MysteryFoxes.Outpost
{
    internal class Zone : MonoBehaviour
    {
        [SerializeField]
        Vector3 size;

        [SerializeField]
        BoxCollider boxCollider;

        ReactiveCommand<IZoneDetectable> detectedInCommand = new();
        ReactiveCommand<IZoneDetectable> detectedOutCommand = new();
        ObservableList<IZoneDetectable> detected = new();

        private void Awake()
        {
            UpdateVisual();
        }

        public Vector3 Size => size;

        public Observable<IZoneDetectable> DetectedInCommand => detectedInCommand;
        public Observable<IZoneDetectable> DetectedOutCommand => detectedOutCommand;
        public IObservableCollection<IZoneDetectable> Detected => detected;


        void UpdateVisual()
        {
            boxCollider.size = size;
            boxCollider.center = new(0, size.y / 2f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IZoneDetectable detectable))
                return;

            if (detected.Contains(detectable))
                return;

            detected.Add(detectable);
            detectedInCommand.Execute(detectable);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IZoneDetectable detectable))
                return;

            if (!detected.Contains(detectable))
                return;

            detected.Remove(detectable);
            detectedOutCommand.Execute(detectable);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateVisual();

            UnityEditor.EditorApplication.delayCall += DelayedValidate;

            void DelayedValidate()
            {
                UnityEditor.EditorApplication.delayCall -= DelayedValidate;
                if (this == null) return;
                gameObject.SendMessage("OnObjectValidate", SendMessageOptions.DontRequireReceiver);
            }
        }
#endif
    }
}
