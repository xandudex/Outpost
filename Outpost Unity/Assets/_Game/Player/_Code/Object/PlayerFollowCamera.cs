using Unity.Cinemachine;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Player
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        [SerializeField]
        CinemachineCamera camera;

        [Inject]
        void Construct(PlayerObject player)
        {
            camera.Target.TrackingTarget = player.transform;
        }
    }
}
