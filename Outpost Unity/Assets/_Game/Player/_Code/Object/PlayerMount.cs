﻿using ObservableCollections;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysteryFoxes.Outpost.Player
{
    internal class PlayerMount : MonoBehaviour
    {
        ReactiveProperty<IMountable> mounted = new();

        [SerializeField]
        InputActionReference mountAction;

        [SerializeField]
        PlayerInteraction playerInteraction;

        Transform initialRootTransform;
        Rigidbody rb;
        public ReadOnlyReactiveProperty<IMountable> Mounted => mounted;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            initialRootTransform = transform.parent;
            playerInteraction.Interactables.ObserveCountChanged()
                               .Subscribe(x => playerInteraction.InteractingWith<IMountable>())
                               .AddTo(this);

            mountAction.action.performed += MountPerformed;
        }
        private void OnDestroy()
        {
            mountAction.action.performed -= MountPerformed;
        }

        private void MountPerformed(InputAction.CallbackContext _)
        {
            if (mounted.Value == null)
                Mount();
            else
                Unmount();
        }

        public bool Mount()
        {
            IMountable mountable = playerInteraction.FirstOf<IMountable>();
            if (mountable == null)
                return false;

            mounted.Value = mountable;
            mountable.Mount();

            rb.isKinematic = true;
            transform.SetParent(mountable.SeatPoint);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            return true;
        }
        public bool Unmount()
        {
            if (mounted.Value == null)
                return false;

            mounted.Value.Unmount();

            rb.isKinematic = false;
            transform.SetParent(initialRootTransform);
            transform.position = mounted.Value.MountPoint.position;

            mounted.Value = null;
            return true;
        }
    }
}
