using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(7f * directionX, playerRigidbody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 14f);
        }
    }
}
