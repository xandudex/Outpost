using UnityEngine;

namespace MysteryFoxes.Outpost.Player
{
    public class PlayerMovementAnimation : MonoBehaviour
    {
        [SerializeField]
        Rigidbody rb;

        [SerializeField]
        Animator animator;

        [SerializeField]
        string speedAnimatorParameter = "speed";

        private void Update()
        {
            animator.SetFloat(speedAnimatorParameter, rb.linearVelocity.magnitude);
        }
    }
}