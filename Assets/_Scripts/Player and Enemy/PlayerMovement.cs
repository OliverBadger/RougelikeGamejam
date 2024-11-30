using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Base movement speed
    public float dashSpeed = 15f; // Speed during a dash
    public float dashDuration = 0.2f; // Duration of the dash
    public float dashCooldown = 1f; // Time between dashes
    public Rigidbody2D rb;

    private Vector2 movementInput; // Input for movement (WASD or Arrow Keys)
    private bool isDashing = false;
    private float dashTime; // Tracks dash duration
    private float dashCooldownTimer = 0f; // Tracks dash cooldown

    void Start()
    {
        
    }

    void Update()
    {
        if (!isDashing)
        {
            // Capture WASD/Arrow Key input
            movementInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
            movementInput.y = Input.GetAxisRaw("Vertical"); // W/S or Up/Down
            movementInput = movementInput.normalized; // Normalize to prevent diagonal speed boost
        }

        // Handle dash input
        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0 && !isDashing)
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
        rb.linearVelocity = movementInput * moveSpeed;
    }

    private void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        dashCooldownTimer = dashCooldown;
    }

    private void DashMovement()
    {
        // Continue dashing in the direction of movement input
        rb.linearVelocity = movementInput * dashSpeed;

        // Reduce the dash timer
        dashTime -= Time.deltaTime;

        if (dashTime <= 0)
        {
            isDashing = false; // End dash
        }
    }
}
