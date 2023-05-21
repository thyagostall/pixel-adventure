using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
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
        }
        else if (directionX < 0f)
        {
            playerAnimator.SetBool("running", true);
        }
        else
        {
            playerAnimator.SetBool("running", false);
        }
    }
}
