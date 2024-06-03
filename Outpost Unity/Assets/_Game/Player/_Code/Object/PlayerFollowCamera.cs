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
        void Construct(IBufferedSubscriber<IEntityObject> playerSubscriber)
        {
            playerSubscriber.Subscribe(PlayerSpawned, x => x is PlayerObject)
                            .AddTo(this);
        }

        private void OnDestroy()
        {
            disposable?.Dispose();
        }

        private void PlayerSpawned(IEntityObject entityObject)
        {
            var playerObject = entityObject as PlayerObject;
            cam.Target.TrackingTarget = playerObject.transform;
        }
    }
}

