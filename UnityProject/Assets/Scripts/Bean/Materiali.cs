using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Materiali 
{
    
    public int id { get; private set; }
    public string descrizione { get; private set; }
    private Colori_Enum colore { get;  set; }


    public string toString()
    {
        return "Materiale{id= " + id +", descrizione= "+ descrizione +", colore= "+ colore.ToString() + "}";
    }

    
}




