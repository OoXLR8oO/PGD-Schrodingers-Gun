using UnityEngine;

namespace TopDown.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed = 2f;
        private Rigidbody2D rb;
        private Transform playerTransform;
        private Vector2 moveDirection;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                Debug.LogError("Player object not found! Make sure it's named 'Player'.");
            }
        }

        private void Update()
        {
            if (playerTransform != null)
            {
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                moveDirection = direction;

                // Rotate to face the player (assuming the sprite points down by default)
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle - 90f; // Subtract 90 if "down" is forward
            }
        }

        private void FixedUpdate()
        {
            if (playerTransform != null)
            {
                rb.linearVelocity = moveDirection * moveSpeed;
            }
        }
    }
}
