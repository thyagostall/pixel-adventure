using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MovementState { idle, running, jumping, falling }

    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(moveSpeed * directionX, playerRigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsTouchingGound())
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }

        MovementState movementState;
        if (directionX > 0f)
        {
            movementState = MovementState.running;
            playerSpriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            movementState = MovementState.running;
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            movementState = MovementState.idle;
        }

        if (playerRigidbody.velocity.y > 0.01f)
        {
            movementState = MovementState.jumping;
        }
        else if (playerRigidbody.velocity.y < -0.01f)
        {
            movementState = MovementState.falling;
        }

        playerAnimator.SetInteger("state", (int) movementState);
    }

    private bool IsTouchingGound()
    {
        return Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
