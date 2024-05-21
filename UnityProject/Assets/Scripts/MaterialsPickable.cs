using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MaterialsPickable : MonoBehaviour
{
    [SerializeField] public Colori_Enum colore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scanner"))
        {
            tiggerato();
        }
        
    }

    private void tiggerato()
    {
        GameEventManager.instance.materialPickedUp.MaterialePiccato(colore);
    }
}
