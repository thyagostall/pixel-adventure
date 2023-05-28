using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
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
        deathSoundEffect.Play();
        playerRigidbody.bodyType = RigidbodyType2D.Static;
        playerAnimator.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
