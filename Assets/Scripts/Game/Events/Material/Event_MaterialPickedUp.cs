using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_MaterialPickedUp 
{
    public static Event_MaterialPickedUp current;
    public event Action<colori> onMaterialPickedUp;
    

    public void MaterialePiccato(colori colori)
    {

        onMaterialPickedUp?.Invoke(colori);
    }
   
}
