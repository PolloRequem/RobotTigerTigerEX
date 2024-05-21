using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSimTrigger : MonoBehaviour
{
    private bool startTriggerd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!startTriggerd)
            {
                GameEventManager.instance.startUpLevel.EndLevel();
                startTriggerd = true;
            }
        }

    }
}
