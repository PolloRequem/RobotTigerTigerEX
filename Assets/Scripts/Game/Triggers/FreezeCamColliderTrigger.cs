using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamColliderTrigger : MonoBehaviour
{
    private bool startTriggerd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            if (!startTriggerd)
            {
                GameEventManager.instance.freezeCam.FreezeCam();
                startTriggerd = true;
            }
        }

    }
}
