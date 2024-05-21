using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_PlayerAttack 
{
    public static Event_PlayerAttack current;
    public event Action onPlayerAttack;

    public void PlayerAttack()
    {
        onPlayerAttack?.Invoke();
    }
}


