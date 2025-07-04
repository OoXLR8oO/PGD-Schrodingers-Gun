using System;
using UnityEngine;

namespace TopDown.Jumping
{
    public class JumpController : MonoBehaviour
    {
        [Header("Jump Settings")]
        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float gravity = 9.8f;
        [SerializeField] private float jumpCooldown = 1.0f;

        private float verticalVelocity = 0f;
        private float zHeight = 0f; // Simulated vertical height
        private bool isJumping = false;
        private float lastJumpTime = -Mathf.Infinity;

        public bool IsJumping => isJumping;
        public float Height => zHeight;

        //[Header("References")]
        //[SerializeField] private Transform shadowTransform;

        private void Jump()
        {
            Debug.Log("OnJump called!");
        }

        private void OnJump()
        {
            TryJump();
        }

        private void HandleJumpPhysics()
        {
            if (isJumping)
            {
                verticalVelocity -= gravity * Time.deltaTime;
                zHeight += verticalVelocity * Time.deltaTime;

                if (zHeight <= 0f)
                {
                    zHeight = 0f;
                    verticalVelocity = 0f;
                    isJumping = false;
                    Debug.Log("Landed.");
                }

                // Optional: adjust scale or visual effect to show height
                float scaleMultiplier = 1 + (zHeight * 0.2f);
                transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1f);
            }
        }

        private void TryJump()
        {
            if (Time.time - lastJumpTime >= jumpCooldown && !isJumping)
            {
                verticalVelocity = jumpForce;
                isJumping = true;
                lastJumpTime = Time.time;
                Debug.Log("Jump started!");
            }
        }

        public void FallIntoHole()
        {
            StartCoroutine(ShrinkAndDisappear());
        }

        private System.Collections.IEnumerator ShrinkAndDisappear()
        {
            float duration = 0.5f;
            float elapsed = 0f;

            Vector3 originalScale = transform.localScale;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                float scale = Mathf.Lerp(originalScale.x, 0f, t);
                transform.localScale = new Vector3(scale, scale, 1f);
                yield return null;
            }

            Debug.Log("Fell into hole!");
            gameObject.SetActive(false); // or Destroy(gameObject);
        }

        private void Update()
        {
            HandleJumpPhysics();
        }
    }
}