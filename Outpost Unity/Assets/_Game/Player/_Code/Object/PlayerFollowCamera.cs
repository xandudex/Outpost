using MessagePipe;
using R3;
using System;
using Unity.Cinemachine;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        [SerializeField]
        CinemachineCamera cam;

        IDisposable disposable;

        [Inject]
        void Construct(IBufferedSubscriber<Player> playerSubscriber)
        {
            playerSubscriber.Subscribe(PlayerSpawned)
                            .AddTo(this);
        }

        private void OnDestroy()
        {
            disposable?.Dispose();
        }

        private void PlayerSpawned(Player player)
        {
            cam.Target.TrackingTarget = player.transform;
        }
    }
}

