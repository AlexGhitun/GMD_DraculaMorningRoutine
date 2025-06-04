using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;
    private bool grounded;
    private int jumpCount = 0;
    private int maxJumps = 2;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dashSound;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDashing)
            return;

        // Handles movement (keyboard A/D or Left Stick X)
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Flip character sprite
        if (horizontalInput > 0f)
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
        else if (horizontalInput < 0f)
            transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);

        // Combine keyboard and controller input for jumping
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton3);
        if (jumpPressed && jumpCount < maxJumps)
        {
            Jump();
            SoundManager.instance.PlaySound(jumpSound);
        }

        // Combine keyboard and controller input for dashing
        bool dashPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton4);
        if (dashPressed && canDash)
        {
            StartCoroutine(Dash());
            SoundManager.instance.PlaySound(dashSound);
        }

        // Update animator parameters
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        anim.SetTrigger("jump");
        jumpCount++;
        grounded = false;

        if (jumpCount == 2)
            tr.emitting = true; // Activate trail on second jump
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumpCount = 0;
            tr.emitting = false;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
