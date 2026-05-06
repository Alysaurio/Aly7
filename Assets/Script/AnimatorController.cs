using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public Animator animator;
    public Vector2 MoveInput;

    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Movement.performed += OnMovementStart;
        inputs.Player.Movement.canceled += OnMovementFinish;

        inputs.Player.Jump.performed += OnJumpStart;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnMovementStart(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        if (MoveInput.x != 0)
            animator.SetBool("IsMoving", true);
        GetComponent<SpriteRenderer>().flipX = (MoveInput.x == -1 && MoveInput.x != 0) ? true : false;
        
    }
    private void OnMovementFinish(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
        animator.SetBool("IsMoving", false);
    }
    private void OnJumpStart(InputAction.CallbackContext context)
    {
        animator.SetTrigger("OnJump");
    }
}
