using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocchiDMG : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventManager.instance.playerDmged.PlayerDmged();
        }
    }
}
