using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hittable : MonoBehaviour
{
 
    public void BasicHit()
    {
        GetHit();
    }
    protected virtual void GetHit()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventManager.instance.playerDmged.PlayerDmged();
        }
    }

    protected virtual void Die()
    {
        GameEventManager.instance.enemyDestroyed.EnemyDestroyed();
        Destroy(gameObject);
    }
}