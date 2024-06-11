using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysteryFoxes.Outpost.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        PlayerMount playerMount;

        [SerializeField]
        PlayerModel player;

        [SerializeField]
        InputActionReference moveAction;

        [SerializeField]
        Rigidbody rb;

        [Space]

        [SerializeField]
        float speedScale;

        [SerializeField]
        float turnSpeed;

        bool canMove = true;
        new Camera camera;

        void Awake()
        {
            camera = Camera.main;
            playerMount.Mounted.Subscribe(x => canMove = x == null)
                               .AddTo(this);
        }
        private void Update()
        {
            if (!canMove) return;

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
            speedVector.y += rb.linearVelocity.y;
            rb.linearVelocity = speedVector;

            float magnitude = speedVector.magnitude;

            if (magnitude > 0.01f)
            {
                Vector3 lookDirection = new Vector3(speedVector.x, 0, speedVector.z);
                Quaternion quaternion = Quaternion.LookRotation(lookDirection);
                quaternion = Quaternion.Slerp(transform.rotation, quaternion, magnitude * turnSpeed * Time.deltaTime);
                rb.MoveRotation(quaternion);
            }
        }
    }
}