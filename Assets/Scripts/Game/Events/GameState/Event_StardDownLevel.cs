using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_StardDownLevel 
{
    public static Event_StardDownLevel current;
    public event Action  onStartDownLevel;

    public void StartDownLevel()
    {
        onStartDownLevel?.Invoke();
    }
}
