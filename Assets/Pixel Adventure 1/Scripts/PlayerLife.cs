using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Spike"))
        {
            return;
        }

        Die();
    }

    private void Die()
    {
        playerAnimator.SetTrigger("death");
    }
}
