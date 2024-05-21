using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tiggerato();
        }
        if (collision.gameObject.CompareTag("hoock"))
        {
            tiggerato();
        }
    }

    private void tiggerato()
    {
        GameEventManager.instance.coinGain.CoinGained();
        Destroy(gameObject, 0.1f);
    }
}
