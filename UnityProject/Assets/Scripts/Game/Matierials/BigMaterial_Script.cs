using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMaterial_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tiggerato();
        }
    }

    private void tiggerato()
    {
        GameEventManager.instance.bigMtaken.BingMtaken();
      //  GameEventManager.instance.endLevel.StartDownLevel();
        Destroy(gameObject, 0.1f);
    }
}


