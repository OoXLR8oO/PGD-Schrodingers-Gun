using UnityEngine;
using TopDown.Jumping;

[RequireComponent(typeof(Collider2D))]
public class FallTrigger : MonoBehaviour
{
    [SerializeField] private Sprite requiredSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && requiredSprite != null && sr.sprite != requiredSprite)
            return;

        // Check if the collider is named "AirCollider"
        if (other.gameObject.name != "AirCollider")
            return;

        // Get the parent object (the player) and its JumpController
        JumpController jumpController = other.GetComponentInParent<JumpController>();
        if (jumpController != null && !jumpController.IsJumping)
        {
            jumpController.FallIntoHole();
        }
    }
}
