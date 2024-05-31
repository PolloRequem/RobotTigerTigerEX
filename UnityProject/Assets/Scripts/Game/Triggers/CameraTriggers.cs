using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    private bool startTriggerd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!startTriggerd)
            {
                GameEventManager.instance.playerDead.PlayerDead();
                startTriggerd = true;
            }
        }

    }
}