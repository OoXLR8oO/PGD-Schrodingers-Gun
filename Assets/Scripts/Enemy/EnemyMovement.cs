using UnityEngine;

namespace TopDown.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed = 2f;
        public float visionRadius = 5f; // The maximum range to detect the player

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
                float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

                if (distanceToPlayer <= visionRadius)
                {
                    Vector2 direction = (playerTransform.position - transform.position).normalized;
                    moveDirection = direction;

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.rotation = angle - 90f;
                }
                else
                {
                    moveDirection = Vector2.zero; // Stop chasing
                }
            }
        }

        private void FixedUpdate()
        {
            if (playerTransform != null)
            {
                rb.linearVelocity = moveDirection * moveSpeed;
            }
        }

        // Optional: for debugging vision in the Scene view
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, visionRadius);
        }
    }
}
