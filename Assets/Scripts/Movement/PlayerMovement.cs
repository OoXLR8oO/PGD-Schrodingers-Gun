using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : Mover
    {
        private void OnMove(InputValue value)
        {
            Debug.Log("OnMove called: " + value.Get<Vector2>());
            Vector3 playerInput = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y);
            currentInput = playerInput;
        }
    }
}
