using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        Player player;

        [SerializeField]
        InputActionReference moveAction;

        [SerializeField]
        Rigidbody rb;

        [Space]

        [SerializeField]
        float speedScale;

        [SerializeField]
        float turnSpeed;

        new Camera camera;

        void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            Transform cameraTransform = camera.transform;
            Vector3 rotation = cameraTransform.rotation.eulerAngles;
            rotation.x = 0;

            Quaternion quaternion1 = Quaternion.Euler(rotation);

            Vector3 forward = quaternion1 * Vector3.forward;
            Vector3 right = quaternion1 * Vector3.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector2 iv = moveAction.action.ReadValue<Vector2>();
            Vector3 speedVector = (forward * iv.y + right * iv.x) * speedScale;

            rb.linearVelocity = speedVector;

            float magnitude = speedVector.magnitude;

            if (magnitude > 0.01f)
            {
                Quaternion quaternion = Quaternion.LookRotation(speedVector);
                quaternion = Quaternion.Slerp(transform.rotation, quaternion, magnitude * turnSpeed * Time.deltaTime);
                rb.MoveRotation(quaternion);
            }
        }
    }
}