using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPickUp : MonoBehaviour
{
    Score score;
    Coins coins;
    Health health;
    UILogicsGame uILogicsGame;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        score = FindObjectOfType<Score>();
        coins = FindObjectOfType<Coins>();
        health = FindObjectOfType<Health>();
        uILogicsGame = FindObjectOfType<UILogicsGame>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUpHeart"))
        {
            Destroy(collision.gameObject);
            if (health.lifes >= health.maxLifes)
            {
                health.lifes = health.maxLifes;
            }
            else
            {
                uILogicsGame.AnimAddHealth(health.lifes);
                health.lifes++;
            }
        }
        else if (collision.CompareTag("PickUpCoin"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("PickUpStar"))
        {
            Destroy(collision.gameObject);
        }
    }
}
