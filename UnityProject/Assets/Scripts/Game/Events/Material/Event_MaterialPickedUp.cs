using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_MaterialPickedUp 
{
    public static Event_MaterialPickedUp current;
    public event Action<Colori_Enum> onMaterialPickedUp;
    

    public void MaterialePiccato(Colori_Enum colore)
    {

        onMaterialPickedUp?.Invoke(colore);
    }
   
}
