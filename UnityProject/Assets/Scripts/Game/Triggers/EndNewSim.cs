using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNewSim : MonoBehaviour
{
   // private bool //startTriggerd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventManager.instance.endSimulationSM.EndSim();
            //if (!startTriggerd)
            //{
            //    GameEventManager.instance.endSimulationSM.EndSim();
            //    //startTriggerd = true;
            //}
        }

    }
}
