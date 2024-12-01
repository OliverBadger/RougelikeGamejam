using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementComp : MonoBehaviour
{
    [Header("Movement Settings")]

    public float moveSpeed = 3f;
    public InputAction moveAction;
    public InputAction attackAction;
    private Animator animator;
    private Rigidbody2D rb;
    public bool isMoving;


    [Header("Dash Settings")]
    public float dashSpeed = 15f; // Speed during a dash
    public float dashCooldown = 1f; // Time between dashes
    public float dashDuration = 0.2f; // Duration of the dash
    public InputAction dashAction;
    private bool isDashing = false;
    private float dashTime; // Tracks dash duration
    private float dashCooldownTimer = 0f; // Tracks dash cooldown
    private Vector2 moveValue;

    private AudioSource audioSource;
    public AudioClip moveSound;
    public AudioClip dashSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Dash");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update game logic here, dont forget to multiply by Time.deltaTime to make it frame rate independent
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        moveValue = new Vector2(moveInput.x, moveInput.y).normalized;
        // Add the movement animation here
        if (moveValue != Vector2.zero)
        {
            if (!animator.GetBool("IsAttacking")) { animator.SetBool("IsRunning", true); }
            // rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveValue);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        // Handle dash input
        if (dashAction.IsPressed() && dashCooldownTimer <= 0 && !isDashing)
        {
            StartDash();
        }

        // Update dash cooldown timer
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            DashMovement();
        }
        else
        {
            NormalMovement();
        }
    }
    private void NormalMovement()
    {
        // Apply normal movement based on input
        rb.linearVelocity = moveValue * moveSpeed;
        if (!audioSource.isPlaying) audioSource.PlayOneShot(moveSound);
    }
    private void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        dashCooldownTimer = dashCooldown;
        audioSource.PlayOneShot(dashSound);

    }
    private void DashMovement()
    {
        // Continue dashing in the direction of movement input
        rb.linearVelocity = moveValue * dashSpeed;

        // Reduce the dash timer
        dashTime -= Time.deltaTime;

        if (dashTime <= 0)
        {
            isDashing = false; // End dash
        }
    }


}
