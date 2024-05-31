using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnderCoollider : MonoBehaviour
{
    private bool startTriggerd = false;
    private bool isUpLevelStarted = false;

    private void Start()
    {
        GameEventManager.instance.startUpLevel.onStartUpLevel += StartUpLevel_onStartUpLevel;
    }

    private void StartUpLevel_onStartUpLevel()
    {
        isUpLevelStarted = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUpLevelStarted)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (!startTriggerd)
                {
                    GameEventManager.instance.endLevel.EndLevel();
                    startTriggerd = true;
                }
            }
        }

       

    }
}
