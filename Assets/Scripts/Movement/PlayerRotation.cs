using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Movement
{
    public class PlayerRotation : Rotator
    {
        private Camera mainCamera;

        [Header("Pivot Transforms")]
        [SerializeField] private Transform pivotTorso;
        [SerializeField] private Transform pivotLegs;

        [Header("Mover Reference")]
        [SerializeField] private Mover playerMover;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

            // Torso rotates to face mouse
            LookAt(pivotTorso, mouseWorldPosition);

            // Legs rotate to face movement direction
            if (playerMover.CurrentInput != Vector3.zero)
            {
                Vector3 legsLookPoint = transform.position + playerMover.CurrentInput.normalized;
                LookAt(pivotLegs, legsLookPoint);
            }
        }
    }
}
