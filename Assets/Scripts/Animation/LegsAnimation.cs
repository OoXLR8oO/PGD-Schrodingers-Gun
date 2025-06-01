using TopDown.Movement;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Animator))]
public class LegsAnimation : MonoBehaviour
{
    [SerializeField] private Mover playerMover;
    private Animator legsAnimator;

    private void Awake()
    {
        legsAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 input = playerMover.CurrentInput;
        legsAnimator.SetBool("moving", input.sqrMagnitude > 0.01f);
    }
}
