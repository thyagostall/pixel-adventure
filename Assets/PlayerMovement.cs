using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(7f * directionX, playerRigidbody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 14f);
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
