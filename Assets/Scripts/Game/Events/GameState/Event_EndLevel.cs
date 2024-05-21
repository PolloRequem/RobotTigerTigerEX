using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_EndLevel 
{
    public static Event_EndLevel current;
    public event Action onEndLevel;

    public void EndLevel()
    {
        onEndLevel?.Invoke();
    }
}
