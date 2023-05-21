using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MovementState { idle, running, jumping, falling }

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(moveSpeed * directionX, playerRigidbody.velocity.y);

        if (Input.GetButtonDown("Jump"))
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
}
