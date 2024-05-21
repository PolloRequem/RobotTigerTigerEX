using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMaterial_Script : MonoBehaviour
{
    private Color targetColor;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      //  ChangeColor();
       
     
       
    }


    //private void ChangeColor()
    //{
    //    if (ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("coloreMissione"), out targetColor))
    //    {
    //        spriteRenderer.color = Color.red;
           
    //    }
    //}
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
        GameEventManager.instance.smallMtaken.SmallMtaken();
        Destroy(gameObject, 0.1f);
    }
}
