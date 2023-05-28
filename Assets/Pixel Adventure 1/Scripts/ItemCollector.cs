using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Cherry"))
        {
            return;
        }

        collectionSoundEffect.Play();
        cherries++;
        cherriesText.text = "Cherries: " + cherries;
        Destroy(collision.gameObject);
    }
}
