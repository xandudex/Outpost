using Unity.Cinemachine;
using UnityEngine;

namespace Game.Player
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        [SerializeField]
        Player player;

        [SerializeField]
        CinemachineCamera camera;

        void Awake()
        {
            camera.Target.TrackingTarget = player.transform;
        }

    }
}
