using System;
using UnityEngine;

namespace TopDown.Jumping
{
    public class JumpController : MonoBehaviour
    {
        [Header("Jump Settings")]
        [SerializeField] private float jumpTime = 1.0f;
        private bool isJumping = false;

        private void Jump()
        {
            Debug.Log("OnJump called!");
        }

        private void OnJump()
        {
            Jump();
        }
    }
}