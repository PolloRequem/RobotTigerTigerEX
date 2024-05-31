using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    private float player_hp = 3;
    private float tempoDiImmuita = 1f;
    private bool eInvulnerabile = false;

    public SpriteRenderer spriteRenderer; 
    public float blinkDuration = 1.0f;
    public float blinkInterval = 0.1f;

  
    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
     
      GameEventManager.instance.playerDmged.onPlayerDmged += PlayerDmged_onPlayerDmged;
    }

    private void PlayerDmged_onPlayerDmged()
    {
   
        if (eInvulnerabile)
        {
            return;
        }

        player_hp--;
        StartCoroutine(Immunita());
        StartCoroutine(Blink());
        //if (player_hp <= 0)
        //{
        //    GameEventManager.instance.playerDead.PlayerDead();
        //}
        //else
        //{
        //    StartCoroutine(Immunita());

        //}
    }


    private IEnumerator Blink()
    {
        float endTime = Time.time + blinkDuration;
        bool isVisible = true;

        while (Time.time < endTime)
        {
          
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;

     
            yield return new WaitForSeconds(blinkInterval);
        }

        
        spriteRenderer.enabled = true;
    }

    private IEnumerator Immunita()
    {
        eInvulnerabile = true;
        yield return new  WaitForSeconds(tempoDiImmuita);
        eInvulnerabile = false;
    }
}
