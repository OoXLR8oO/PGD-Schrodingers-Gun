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
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0f; // Ensure z is grounded

            LookAt(pivotTorso, mouseWorldPosition);

            Vector3 input = playerMover.CurrentInput;
            if (input.sqrMagnitude > 0.01f)
            {
                Vector3 legsLookPoint = transform.position + input.normalized;
                legsLookPoint.z = 0f;
                LookAt(pivotLegs, legsLookPoint);
            }
        }
    }
}