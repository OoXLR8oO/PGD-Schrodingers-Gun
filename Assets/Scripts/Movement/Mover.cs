using UnityEngine;

namespace TopDown.Movement
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        protected Vector3 currentInput;
        public Vector2 CurrentInput => currentInput;


        [SerializeField] private float moveSpeed;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb2d.linearVelocity = moveSpeed * CurrentInput * Time.deltaTime;
        }
    }
}
