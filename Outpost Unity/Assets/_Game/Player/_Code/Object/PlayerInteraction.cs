using ObservableCollections;
using System.Linq;
using UnityEngine;
namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerInteraction : MonoBehaviour
    {
        ObservableList<IInteractable> interactables = new();

        public IObservableCollection<IInteractable> Interactables => interactables;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            interactables.Add(interactable);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            interactables.Remove(interactable);
        }

        public bool InteractingWith<T>() where T : IInteractable
            => interactables.Any(x => x is T);
        public T FirstOf<T>() where T : IInteractable
            => (T)interactables.FirstOrDefault(x => x is T);
    }
}