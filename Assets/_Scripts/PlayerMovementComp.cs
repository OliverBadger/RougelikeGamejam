using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementComp : MonoBehaviour
{

    public float moveSpeed;
    public InputAction moveAction;
    public InputAction attackAction;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isMoving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update game logic here, dont forget to multiply by Time.deltaTime to make it frame rate independent
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        var moveValue = new Vector2(moveInput.x, moveInput.y).normalized;
        // Add the movement animation here
        if (moveValue != Vector2.zero)
        {
            if (!animator.GetBool("IsAttacking")) { animator.SetBool("IsRunning", true); }
            rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveValue);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }



}
