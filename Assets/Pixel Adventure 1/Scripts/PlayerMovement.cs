using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

        if (directionX > 0f)
        {
            playerAnimator.SetBool("running", true);
            playerSpriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            playerAnimator.SetBool("running", true);
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            playerAnimator.SetBool("running", false);
        }
    }
}
