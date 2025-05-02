using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

namespace TopDown.Movement
{
    public class PlayerRotation : Rotator
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue(); // Requires using UnityEngine.InputSystem
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            LookAt(mouseWorldPosition);
        }

        // This only gets called when the mouse moves.
        //private void OnLook(InputValue value)
        //{
        //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        //    LookAt(mousePosition);
        //}
    }
}
