using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_FreezeCam 
{
    public static Event_FreezeCam current;
    public event Action onFreezeCam;

    public void FreezeCam()
    {
        onFreezeCam?.Invoke();
    }
}
