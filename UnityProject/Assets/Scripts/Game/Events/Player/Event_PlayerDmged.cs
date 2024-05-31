using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_PlayerDmged 
{
    public static Event_PlayerDmged current;
    public event Action onPlayerDmged;

    public void PlayerDmged()
    {
        onPlayerDmged?.Invoke();
      
    }
}
