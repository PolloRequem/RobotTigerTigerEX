using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_StartUpLevel 
{
    public static Event_StartUpLevel current;
    public event Action onStartUpLevel;

    public void EndLevel()
    {
        onStartUpLevel?.Invoke();
    }
}
