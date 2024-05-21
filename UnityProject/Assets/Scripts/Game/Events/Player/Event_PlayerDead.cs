using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_PlayerDead 
{

    public static Event_PlayerDead current;
    public event Action onPlayerDead;

    public void PlayerDead()
    {
        onPlayerDead?.Invoke();
    }
}

