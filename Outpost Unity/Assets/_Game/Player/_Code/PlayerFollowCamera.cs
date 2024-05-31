using Unity.Cinemachine;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        [SerializeField]
        CinemachineCamera camera;

        [Inject]
        void Construct(Player player)
        {
            camera.Target.TrackingTarget = player.transform;
        }
    }
}
