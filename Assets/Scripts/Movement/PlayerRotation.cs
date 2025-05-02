using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

namespace TopDown.Movement
{
    public class PlayerRotation : Rotator
    {
        private Camera mainCamera;

        [Header("Torso & Legs Transform")]
        [SerializeField] private Transform torso;
        [SerializeField] private Transform legs;

        [Header("Mover Reference")]
        [SerializeField] private Mover playerMover;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue(); // Requires using UnityEngine.InputSystem
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 legsLookPoint = transform.position + new Vector3(playerMover.CurrentInput.x, playerMover.CurrentInput.y);

            LookAt(torso, mouseWorldPosition);
            LookAt(legs, Vector3.zero);
        }

        // This only gets called when the mouse moves.
        //private void OnLook(InputValue value)
        //{
        //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        //    LookAt(mousePosition);
        //}
    }
}
