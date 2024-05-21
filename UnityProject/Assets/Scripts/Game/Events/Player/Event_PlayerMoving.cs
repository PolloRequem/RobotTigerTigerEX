using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_PlayerMoving 
{
    public static Event_PlayerMoving current;
    public event Action onPlayerMoving;

    public void PlayerMoving()
    {
        onPlayerMoving?.Invoke();
    }
}

