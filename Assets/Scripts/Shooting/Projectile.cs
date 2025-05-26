using Unity.VisualScripting;
using UnityEngine;

namespace TopDown.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [Header("Movement Stats")]
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;

        private Rigidbody2D rb2d;
        private float lifeTimer;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void ShootBullet(Transform shootPoint)
        {
            lifeTimer = 0;
            rb2d.linearVelocity = Vector2.zero;
            transform.position = shootPoint.position;
            transform.rotation = shootPoint.rotation;
            gameObject.SetActive(true);

            rb2d.AddForce(-transform.up * speed, ForceMode2D.Impulse);
        }

        private void Update()
        {
            lifeTimer += Time.deltaTime;
            if (lifeTimer > lifetime)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Triggered with: " + other.gameObject.name);

            if (other.CompareTag("Obstacles"))
            {
                Destroy(gameObject);
            }
        }
    }
}
